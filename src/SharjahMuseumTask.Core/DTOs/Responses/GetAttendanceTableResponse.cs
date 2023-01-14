using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharjahMuseumTask.Core.Models;

namespace SharjahMuseumTask.Core.DTOs.Responses
{
    public class GetAttendanceTableResponse
    {
        public GetAttendanceTableResponse()
        {
            EmpAttendanceReport = new EmpAttendanceReport() ;
        }
        public EmpAttendanceReport EmpAttendanceReport { get; set; }
    }
}
