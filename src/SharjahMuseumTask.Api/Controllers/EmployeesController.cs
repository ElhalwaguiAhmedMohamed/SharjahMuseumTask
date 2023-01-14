using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SharjahMuseumTask.Core.DTOs.Requests;
using SharjahMuseumTask.Core.DTOs.Responses;
using SharjahMuseumTask.Core.Interfaces;
using SharjahMuseumTask.Core.Services;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace SharjahMuseumTask.Api.Controllers
{
    [ApiController]
    [Route("api/")]
    [Authorize]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<UsersController> _logger;
        private readonly IConfiguration _configuration;
        public EmployeesController(IEmployeeService employeeService, ILogger<UsersController> logger, IConfiguration configuration)
        {
            _employeeService = employeeService;
            _logger = logger;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("[controller]/[action]")]
        [Authorize(Roles = "ADMIN")]
        public GetAllEmployeesResponse GetAllEmployees([FromBody] GetAllEmployeesRequest request)
        {
            var employees = _employeeService.GetAll(request);
            var res = new GetAllEmployeesResponse();
            res.Employees.AddRange(employees);
            return res;
        }

        [HttpPost]
        [Route("[controller]/[action]")]
        [Authorize(Roles = "ADMIN")]
        public GetEmployeeByIdResponse GetEmployeeById([FromBody] GetEmployeeByIdRequest request)
        {
            var employee = _employeeService.GetById(request.EmployeeId);
            var res = new GetEmployeeByIdResponse
            {
                Employee = employee,
            };
            return res;
        }

        [HttpPost]
        [Route("[controller]/[action]")]
        [Authorize(Roles = "ADMIN")]
        public async Task<UpdateEmployeeResponse> UpdateEmployee([FromBody] UpdateEmployeeRequest request)
        {
            var ret = await _employeeService.UpdateOne(request.Employee);
            var res = new UpdateEmployeeResponse
            {
                DoneUpdate = ret,
            };
            return res;
        }

        [HttpPost]
        [Route("[controller]/[action]")]
        [Authorize(Roles = "ADMIN")]
        public DeleteEmployeeResponse DeleteEmployee([FromBody] DeleteEmployeeRequest request)
        {
            var ret = _employeeService.DeleteOne(request.EmployeeId);
            var res = new DeleteEmployeeResponse
            {
                DoneDelete = ret,
            };
            return res;
        }

        [HttpPost]
        [Route("[controller]/[action]")]
        [Authorize(Roles = "ADMIN")]
        public AddEmployeeResponse AddEmployee([FromBody] AddEmployeeRequest request)
        {
            var ret = _employeeService.AddOne(request.Employee);
            var res = new AddEmployeeResponse
            {
                DoneAdding = ret,
            };
            return res;
        }

    }
}
