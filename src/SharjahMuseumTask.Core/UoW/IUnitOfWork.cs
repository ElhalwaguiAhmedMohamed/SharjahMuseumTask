using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharjahMuseumTask.Core.Models;
using SharjahMuseumTask.Core.Repositories;

namespace SharjahMuseumTask.Core.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<User> Users { get; }
        IBaseRepository<Device> Devices { get; }
        IBaseRepository<Role> Roles { get; }
        IBaseRepository<Employee> Employees { get; }
        IBaseRepository<EmpAttendance> EmpAttendances { get; }
        int Complete();
    }
}
