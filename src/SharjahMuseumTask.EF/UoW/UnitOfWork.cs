using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharjahMuseumTask.Core.Models;
using SharjahMuseumTask.Core.Repositories;
using SharjahMuseumTask.Core.UoW;
using SharjahMuseumTask.EF.Repositories;

namespace SharjahMuseumTask.EF.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IBaseRepository<User> Users { get; private set; }
        public IBaseRepository<Device> Devices { get; private set; }
        public IBaseRepository<Role> Roles { get; private set; }
        public IBaseRepository<Employee> Employees { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Users = new BaseRepository<User>(_context!);
            Devices = new BaseRepository<Device>(_context!);
            Roles = new BaseRepository<Role>(_context!);
            Employees = new BaseRepository<Employee>(_context!);
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
