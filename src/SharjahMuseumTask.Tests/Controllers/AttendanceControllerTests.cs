using FakeItEasy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SharjahMuseumTask.Api.Controllers;
using SharjahMuseumTask.Core.Interfaces;
using System;
using FluentAssertions;
using SharjahMuseumTask.Core.DTOs;
using SharjahMuseumTask.Core.DTOs.Requests;
using SharjahMuseumTask.Core.DTOs.Responses;
using SharjahMuseumTask.Core.Models;
using Xunit;

namespace SharjahMuseumTask.Tests.Controllers
{
    public class AttendanceControllerTests
    {
        private IAttendanceService fakeAttendanceService;
        private ILogger<UsersController> fakeLogger;
        private IConfiguration fakeConfiguration;

        public AttendanceControllerTests()
        {
            this.fakeAttendanceService = A.Fake<IAttendanceService>();
            this.fakeLogger = A.Fake<ILogger<UsersController>>();
            this.fakeConfiguration = A.Fake<IConfiguration>();
        }

        private AttendanceController CreateAttendanceController()
        {
            return new AttendanceController(
                this.fakeAttendanceService,
                this.fakeLogger,
                this.fakeConfiguration);
        }

        [Fact]
        public void GetAttendanceTable_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var attendanceController = this.CreateAttendanceController();
            GetAttendanceTableRequest request = new GetAttendanceTableRequest();
            var expectedServoiceReturn = new EmpAttendanceReport
            {
                Rows = new List<ReportRow>
                {
                    new ReportRow
                    {
                        UserId = 1
                    }
                }
            };
            A.CallTo(() => fakeAttendanceService.GetAttendanceTable(request)).Returns(expectedServoiceReturn);
            // Act
            var result = attendanceController.GetAttendanceTable(
                request);

            // Assert
            result.EmpAttendanceReport.Rows.Count.Should().Be(1);
            result.EmpAttendanceReport.Rows[0].UserId.Should().Be(1);
        }
    }
}
