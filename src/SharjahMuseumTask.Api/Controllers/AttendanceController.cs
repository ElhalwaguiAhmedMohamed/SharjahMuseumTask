using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharjahMuseumTask.Core.DTOs.Requests;
using SharjahMuseumTask.Core.DTOs.Responses;
using SharjahMuseumTask.Core.Interfaces;
using SharjahMuseumTask.Core.Services;

namespace SharjahMuseumTask.Api.Controllers
{
    [ApiController]
    [Route("api/")]
    [Authorize]
    public class AttendanceController : Controller
    {
        private readonly IAttendanceService _attendanceService;
        private readonly ILogger<UsersController> _logger;
        private readonly IConfiguration _configuration;
        public AttendanceController(IAttendanceService attendanceService, ILogger<UsersController> logger, IConfiguration configuration)
        {
            _attendanceService = attendanceService;
            _logger = logger;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("[controller]/[action]")]
        [Authorize(Roles = "ADMIN")]
        public GetAttendanceTableResponse GetAttendanceTable([FromBody] GetAttendanceTableRequest request)
        {
            var ret = _attendanceService.GetAttendanceTable(request).ToList();
            var res = new GetAttendanceTableResponse();
            res.AttendanceTable.AddRange(ret);
            return res;
        }
    }
}
