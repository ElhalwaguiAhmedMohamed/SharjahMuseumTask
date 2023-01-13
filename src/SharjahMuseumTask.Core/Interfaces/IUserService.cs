using Microsoft.IdentityModel.Tokens;
using SharjahMuseumTask.Core.DTOs.Requests;
using SharjahMuseumTask.Core.DTOs.Responses;
using SharjahMuseumTask.Core.Models;

namespace SharjahMuseumTask.Core.Interfaces
{
    public interface IUserService
    {
        public User GetById(int id);
        public LoginResponse Login(LoginRequest request, SigningCredentials credentials, string issuer, string audience);
    }
}
