using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Calisanlar.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public string SicilNo { get; set; }
        public List<Employee> Astlar { get; set; }
        public Employee Ust { get; set; }
    }
}
