using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SharjahMuseumTask.Core.DTOs.Requests;
using SharjahMuseumTask.Core.DTOs.Responses;
using SharjahMuseumTask.Core.Interfaces;
using SharjahMuseumTask.Core.Models;

namespace SharjahMuseumTask.Api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;   
        private readonly ILogger<UsersController> _logger;
        private readonly IConfiguration _configuration;
        public UsersController(IUserService userService, ILogger<UsersController> logger, IConfiguration configuration)
        {
            _userService = userService;
            _logger = logger;
            _configuration = configuration;
        }
        [HttpPost]
        [Route("[controller]/[action]")]
        public LoginResponse Login([FromBody] LoginRequest request)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            return _userService.Login(request, credentials,issuer,audience);
        }

    }
}
