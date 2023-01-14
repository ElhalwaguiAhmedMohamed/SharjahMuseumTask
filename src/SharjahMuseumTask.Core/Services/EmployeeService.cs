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
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Employee> GetAll(GetAllEmployeesRequest request)
        {
            return _unitOfWork.Employees.GetAll();
        }

        public Employee GetById(int id)
        {
            return _unitOfWork.Employees.GetById(id);
        }

        public async Task<bool> UpdateOne(Employee employee)
        {
            var currentEmp = await _unitOfWork.Employees.GetByIdAsync(employee.EmpId);
            currentEmp.Email = employee.Email;
            currentEmp.Name = employee.Name;
            currentEmp.PhoneNumber = employee.PhoneNumber;
            //_unitOfWork.Employees.Update(employee, employee.EmpId);
            var count = _unitOfWork.Complete();
            if (count > 0) return true;
            return false;
        }

        public bool DeleteOne(int id)
        {
            var employee = _unitOfWork.Employees.GetById(id);
            _unitOfWork.Employees.Delete(employee);
            var count = _unitOfWork.Complete();
            if (count > 0) return true;
            return false;
        }

        public bool AddOne(Employee employee)
        {
            var addedEmployee = _unitOfWork.Employees.Add(employee);
            if (addedEmployee != null)
            {
                _unitOfWork.Complete();
                return true;
            };
            return false;
        }
    }
}
