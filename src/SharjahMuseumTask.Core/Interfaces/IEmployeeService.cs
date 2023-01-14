using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharjahMuseumTask.Core.DTOs.Requests;
using SharjahMuseumTask.Core.Models;

namespace SharjahMuseumTask.Core.Interfaces
{
    public interface IEmployeeService
    {
        public IEnumerable<Employee> GetAll(GetAllEmployeesRequest request);
        public Employee GetById(int id);
        public Task<bool> UpdateOne(Employee employee);
        public bool DeleteOne(int id);
        public bool AddOne(Employee employee);
    }
}
