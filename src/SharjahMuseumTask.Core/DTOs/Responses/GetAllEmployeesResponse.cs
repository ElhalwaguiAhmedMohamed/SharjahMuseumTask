using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharjahMuseumTask.Core.Models;

namespace SharjahMuseumTask.Core.DTOs.Responses
{
    public class GetAllEmployeesResponse
    {
        public GetAllEmployeesResponse()
        {
            Employees = new List<Employee>();
        }
        public List<Employee> Employees { get; set; }
    }
}
