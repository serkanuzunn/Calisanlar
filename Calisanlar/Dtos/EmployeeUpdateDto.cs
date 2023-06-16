using Employees.Models;
using System.Collections.Generic;

namespace Employees.Dtos
{
    public class EmployeeUpdateDto
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public string SicilNo { get; set; }
        public List<Employee> Astlar { get; set; }
        public Employee Ust { get; set; }
    }
}
