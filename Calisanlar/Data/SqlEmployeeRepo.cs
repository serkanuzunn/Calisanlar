using Employees.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Calisanlar.Data
{
    public class SqlEmployeeRepo : IEmployeeRepo
    {

        private readonly EmployeeContext _context;

        public SqlEmployeeRepo(EmployeeContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.Employees.Include(p => p.Astlar).ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            return _context.Employees.Include(p => p.Astlar).FirstOrDefault(p => p.Id == id);
        }

        public void CreateEmployee(Employee emp)
        {
            if (emp==null)
            {
                throw new ArgumentException(nameof(emp));
            }

            _context.Employees.Add(emp);
        }

        public void UpdateEmployee(Employee emp)
        {
            //Nothing
        }

        public void DeleteEmployee(Employee emp)
        {
            _context.Employees.Remove(emp);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
