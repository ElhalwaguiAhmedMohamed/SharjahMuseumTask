using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NLog;
using NLog.Web;
using SharjahMuseumTask.Core.Interfaces;
using SharjahMuseumTask.Core.Repositories;
using SharjahMuseumTask.Core.Services;
using SharjahMuseumTask.Core.UoW;
using SharjahMuseumTask.EF;
using SharjahMuseumTask.EF.Repositories;
using SharjahMuseumTask.EF.UoW;

namespace SharjahMuseumTask.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
            logger.Debug("init main");
            try
            {
                var builder = WebApplication.CreateBuilder(args);
                // Add services to the container.
                builder.Services.AddControllers();
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();
                builder.Services.AddCors();
                builder.Services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
                builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
                builder.Services.AddScoped(typeof(IUserService), typeof(UserService));
                builder.Services.AddScoped(typeof(IEmployeeService), typeof(EmployeeService));
                builder.Services.AddScoped(typeof(IAttendanceService), typeof(AttendanceService));
                // NLog: Setup NLog for Dependency injection
                builder.Logging.ClearProviders();
                builder.Host.UseNLog();
                var x = builder.Configuration["Jwt:Issuer"];
                var y = builder.Configuration["Jwt:Audience"];
                var z = builder.Configuration["Jwt:Key"];
                // JWT bearer 
                builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                    options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = builder.Configuration["Jwt:Issuer"],
                            ValidAudience = builder.Configuration["Jwt:Audience"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                        };
                    });
                var app = builder.Build();
                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseHttpsRedirection();

                app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
                app.UseAuthentication();
                app.UseAuthorization();

                app.MapControllers();

                app.Run();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Stopped program because of exception");
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
            

        }
    }
}