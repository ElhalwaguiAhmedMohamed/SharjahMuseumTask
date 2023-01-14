using FakeItEasy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SharjahMuseumTask.Api.Controllers;
using SharjahMuseumTask.Core.Interfaces;
using System;
using SharjahMuseumTask.Core.DTOs.Requests;
using SharjahMuseumTask.Core.DTOs.Responses;
using Xunit;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using FluentAssertions;

namespace SharjahMuseumTask.Tests.Controllers
{
    public class UsersControllerTests
    {
        private IUserService fakeUserService;
        private ILogger<UsersController> fakeLogger;
        private IConfiguration configuration;

        public UsersControllerTests()
        {
            this.fakeUserService = A.Fake<IUserService>();
            this.fakeLogger = A.Fake<ILogger<UsersController>>();
            this.configuration = new ConfigurationManager();
        }

        private UsersController CreateUsersController()
        {
            return new UsersController(
                this.fakeUserService,
                this.fakeLogger,
                this.configuration);
        }

        [Fact]
        public void Login_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var usersController = this.CreateUsersController();
            LoginRequest request = new LoginRequest
            {
                Password = "123",
                UserName = "TheGrayWizard",
            };
            var expectedServiceReturn = new LoginResponse
            {
                Token = "TheGrayWizard May come in the castle "
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("fool of a tok"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            A.CallTo(() => fakeUserService.Login(request,credentials,"Sam","Gandalf")).Returns(expectedServiceReturn);
            // Act
            var result = usersController.Login(
                request) as ObjectContent;

            // Assert
            result.Value.As<LoginResponse>().Token.Should().Be(expectedServiceReturn.Token);
        }
    }
}
