using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharjahMuseumTask.Core.Models;

namespace SharjahMuseumTask.Core.DTOs.Responses
{
    public class GetEmployeeByIdResponse
    {
        public Employee Employee { get; set; }
    }
}
