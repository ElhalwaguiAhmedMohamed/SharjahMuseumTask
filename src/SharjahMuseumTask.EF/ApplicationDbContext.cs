using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SharjahMuseumTask.Core.Models;

namespace SharjahMuseumTask.EF
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<EmpAttendance> EmpAttendances { get; set; }
    }
}
