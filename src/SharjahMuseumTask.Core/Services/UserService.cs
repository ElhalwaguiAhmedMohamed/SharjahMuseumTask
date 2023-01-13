using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using SharjahMuseumTask.Core.DTOs.Requests;
using SharjahMuseumTask.Core.DTOs.Responses;
using SharjahMuseumTask.Core.Interfaces;
using SharjahMuseumTask.Core.Models;
using SharjahMuseumTask.Core.Repositories;
using SharjahMuseumTask.Core.UoW;

namespace SharjahMuseumTask.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public LoginResponse Login(LoginRequest request, SigningCredentials credentials, string issuer, string audience)
        {
            var user = _unitOfWork.Users.Find(u => u.UserName == request.UserName && u.Password == request.Password, new[] {"Role"});

            if (user == null) return null;

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Role, user.Role.Name),
            };

            var t = new JwtSecurityToken(
                issuer,audience,
                claims,
                expires:DateTime.Now.AddMinutes(100),
                signingCredentials:credentials);
            var token = new JwtSecurityTokenHandler().WriteToken(t);
            return new LoginResponse
            {
                Token = token
            };
        }
        
        public User GetById(int id)
        {
            return _unitOfWork.Users.GetById(id);
        }
    }
}
