using Employees.Models;
using System.Collections.Generic;

namespace Employees.Dtos
{
    public class EmployeeCreateDto
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public string SicilNo { get; set; }
        public List<EmployeeCreateDto> Astlar { get; set; }
        public Employee Ust { get; set; }
    }
}
