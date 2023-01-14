using FakeItEasy;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SharjahMuseumTask.Api.Controllers;
using SharjahMuseumTask.Core.Interfaces;
using SharjahMuseumTask.Core.DTOs.Requests;
using SharjahMuseumTask.Core.DTOs.Responses;
using SharjahMuseumTask.Core.Models;

namespace SharjahMuseumTask.Tests.Controllers
{
    public class EmployeesControllerTests
    {
        private IEmployeeService fakeEmployeeService;
        private ILogger<UsersController> fakeLogger;
        private IConfiguration fakeConfiguration;

        public EmployeesControllerTests()
        {
            this.fakeEmployeeService = A.Fake<IEmployeeService>();
            this.fakeLogger = A.Fake<ILogger<UsersController>>();
            this.fakeConfiguration = A.Fake<IConfiguration>();
        }

        private EmployeesController CreateEmployeesController()
        {
            return new EmployeesController(
                this.fakeEmployeeService,
                this.fakeLogger,
                this.fakeConfiguration);
        }

        [Fact]
        public void GetAllEmployees_EndPointResponse_ValidResponse()
        {
            // Arrange
            var employeesController = this.CreateEmployeesController();
            GetAllEmployeesRequest request = new GetAllEmployeesRequest();
            var expectedServiceReturn = new List<Employee>
            {
                new Employee
                {
                    EmpId = 1,
                    Name = "Bilbo"
                }
            };
            A.CallTo(() => fakeEmployeeService.GetAll(request)).Returns(expectedServiceReturn);
            // Act
            var result = employeesController.GetAllEmployees(
                request);

            // Assert
            result.Employees.Count.Should().Be(1);
            result.Employees[0].Name.Should().Be("Bilbo");
        }

        [Fact]
        public void GetEmployeeById_EndPointResponse_ValidResponse()
        {
            // Arrange
            var employeesController = this.CreateEmployeesController();
            GetEmployeeByIdRequest request = new GetEmployeeByIdRequest
            {
                EmployeeId = 1
            };
            var expectedServiceReturn = new Employee
            {
                EmpId = 1,
                Name = "Bilbo"
            };
            A.CallTo(() => fakeEmployeeService.GetById(request.EmployeeId)).Returns(expectedServiceReturn);
            // Act
            var result = employeesController.GetEmployeeById(
                request);

            // Assert
            result.Employee.EmpId.Should().Be(1);
            result.Employee.Name.Should().Be("Bilbo");
        }

        [Fact]
        public async Task UpdateEmployee_EndPointResponse_ValidResponse()
        {
            // Arrange
            var employeesController = this.CreateEmployeesController();
            UpdateEmployeeRequest request = new UpdateEmployeeRequest
            {
                Employee = new Employee
                {
                    EmpId = 1,
                    Name = "Bilbo"
                }
            };
            var expectedServiceReturn = true;
            A.CallTo(() => fakeEmployeeService.UpdateOne(request.Employee)).Returns(expectedServiceReturn);
            // Act
            var result = await employeesController.UpdateEmployee(
                request);

            // Assert
            result.DoneUpdate.Should().BeTrue();
        }

        [Fact]
        public void DeleteEmployee_EndPointResponse_ValidResponse()
        {
            // Arrange
            var employeesController = this.CreateEmployeesController();
            DeleteEmployeeRequest request = new DeleteEmployeeRequest
            {
                EmployeeId = 1
            };
            var expectedServiceRetrun = true;
            A.CallTo(() => fakeEmployeeService.DeleteOne(request.EmployeeId)).Returns(expectedServiceRetrun);
            // Act
            var result = employeesController.DeleteEmployee(
                request);

            // Assert
            result.DoneDelete.Should().BeTrue();
        }

        [Fact]
        public void AddEmployee_EndPointResponse_ValidResponse()
        {
            // Arrange
            var employeesController = this.CreateEmployeesController();
            AddEmployeeRequest request = new AddEmployeeRequest
            {
                Employee = new Employee
                {
                    Email = "Bilbo@gmail.com",
                    EmpId = 1,
                    Name = "Bilbo"
                }
            };
            var expectedServiceReturn = true;
            A.CallTo(() => fakeEmployeeService.AddOne(request.Employee)).Returns(expectedServiceReturn);
            // Act
            var result = employeesController.AddEmployee(
                request);

            // Assert
            result.DoneAdding.Should().BeTrue();
        }
    }
}
