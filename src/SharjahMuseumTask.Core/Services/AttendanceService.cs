using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharjahMuseumTask.Core.DTOs.Requests;
using SharjahMuseumTask.Core.Interfaces;
using SharjahMuseumTask.Core.Models;
using SharjahMuseumTask.Core.UoW;

namespace SharjahMuseumTask.Core.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AttendanceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<EmpAttendance> GetAttendanceTable(GetAttendanceTableRequest request)
        {
            var empAttendances = _unitOfWork.EmpAttendances.FindAll(a => true,new[]{"Employee","Device"});
            return empAttendances;
        }
    }
}
