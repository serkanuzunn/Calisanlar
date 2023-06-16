using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employees.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public string SicilNo { get; set; }
        [ForeignKey("Ust")]
        public int? UstId { get; set; }
        public Employee Ust { get; set; }

        public List<Employee> Astlar { get; set; }
    }
}
