using Calisanlar.Models;
using System.Collections.Generic;

namespace Calisanlar.Data
{
    public interface IEmployeeRepo
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        void CreateEmployee(Employee emp);
        void UpdateEmployee(Employee emp);
        void DeleteEmployee(Employee emp);

        bool SaveChanges();
    }
}
