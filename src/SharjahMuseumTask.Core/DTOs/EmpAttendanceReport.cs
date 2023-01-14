using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharjahMuseumTask.Core.DTOs
{
    public class EmpAttendanceReport
    {
        public EmpAttendanceReport()
        {
            Rows = new List<ReportRow>();
        }
        public List<ReportRow> Rows { get; set; }
    }

    public class ReportRow
    {
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string FirstRecordedDateTime { get; set; }
        public string LastRecordedDateTime { get; set; }
    }
}
