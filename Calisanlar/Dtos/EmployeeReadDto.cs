using Employees.Models;
using System.Collections.Generic;

namespace Employees.Dtos
{
    public class EmployeeReadDto
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public string SicilNo { get; set; }
        public List<EmployeeReadDto> Astlar { get; set; }
        //public EmployeeReadDto Ust { get; set; }
    }
}
