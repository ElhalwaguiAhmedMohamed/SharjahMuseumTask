using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharjahMuseumTask.Core.DTOs.Requests;
using SharjahMuseumTask.Core.Models;

namespace SharjahMuseumTask.Core.Interfaces
{
    public interface IAttendanceService
    {
        public IEnumerable<EmpAttendance> GetAttendanceTable(GetAttendanceTableRequest request);
    }
}


