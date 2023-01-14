using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharjahMuseumTask.Core.DTOs;
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
        public EmpAttendanceReport GetAttendanceTable(GetAttendanceTableRequest request)
        {
            var empAttendances = _unitOfWork.EmpAttendances.FindAll(a => a.EmpId == request.EmployeeId).ToList();
            var query = from row in empAttendances
                group row by row.SRVDT.Date
                into dateGroup
                select new
                {
                    UserID = dateGroup.First().EmpId,
                    Date = dateGroup.Key,
                    FirstRecordDateTime = dateGroup.Min(r => DateTimeOffset.FromUnixTimeSeconds(long.Parse(r.DEVDT)).Hour) + ":" + dateGroup.Min(r => DateTimeOffset.FromUnixTimeSeconds(long.Parse(r.DEVDT)).Minute),
                    LastRecordDateTime = dateGroup.Max(r => DateTimeOffset.FromUnixTimeSeconds(long.Parse(r.DEVDT)).Hour) + ":" + dateGroup.Max(r => DateTimeOffset.FromUnixTimeSeconds(long.Parse(r.DEVDT)).Minute),
                    AM_PM_FIRST = dateGroup.Min(r => DateTimeOffset.FromUnixTimeSeconds(long.Parse(r.DEVDT)).Hour) > 12 ? "PM" : "AM",
                    AM_PM_LAST = dateGroup.Max(r => DateTimeOffset.FromUnixTimeSeconds(long.Parse(r.DEVDT)).Hour) > 12 ? "PM" : "AM",
                };
            var report = new EmpAttendanceReport();
            foreach (var r in query)
            {
                var row = new ReportRow
                {
                    UserId = r.UserID,
                    Date = r.Date,
                    FirstRecordedDateTime = r.FirstRecordDateTime + " " +r.AM_PM_FIRST,
                    LastRecordedDateTime = r.LastRecordDateTime + " " + r.AM_PM_LAST,
                };
                report.Rows.Add(row);
            }
            return report;
        }
    }
}
