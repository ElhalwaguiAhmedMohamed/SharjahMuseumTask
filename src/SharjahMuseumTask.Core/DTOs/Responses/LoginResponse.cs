using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharjahMuseumTask.Core.DTOs.Responses
{
    public class LoginResponse
    {
        public string Token { get; set; }
    }
}
