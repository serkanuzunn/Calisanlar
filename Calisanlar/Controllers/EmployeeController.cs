using Calisanlar.Data;
using Calisanlar.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Calisanlar.Controllers
{
    [ApiController]
    public class EmployeeController:ControllerBase
    {
        private IEmployeeRepo _repository;

        public EmployeeController(IEmployeeRepo repository)
        {
            _repository = repository;
        }

        private object GetEmployeeTree(Employee employee)
        {
            var tree = new
            {
                AdSoyad = employee.AdSoyad,
                SicilNo = employee.SicilNo,
                Astlar = new List<object>()
            };

            if (employee.Astlar != null)
            {
                foreach (var ast in employee.Astlar)
                {
                    var astTree = GetEmployeeTree(ast);
                    ((List<object>)tree.Astlar).Add(astTree);
                }
            }

            return tree;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAllEmployees()
        {
            var rootEmployees = _repository.GetAllEmployees().ToList();
            List<object> employeeTree = new List<object>();
            foreach (var employee in rootEmployees)
            {
                var tree = GetEmployeeTree(employee);
                employeeTree.Add(tree);
            }

            return Ok(employeeTree);
        }

        [HttpPost]
        public ActionResult<Employee> CreateEmployee (Employee employee)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");

            if (employee.SicilNo.Length != 11 || !employee.SicilNo.All(char.IsLetterOrDigit))
                return BadRequest("Invalid Sicil No");

            _repository.CreateEmployee(employee);
            _repository.SaveChanges();
            
            return Ok();
        }


        [HttpPut("{id}")]
        public ActionResult UpdateEmployee(int id, Employee employee) 
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");


            var existingEmployee=_repository.GetEmployeeById(id);
            if (existingEmployee == null)
                return BadRequest();

            existingEmployee.AdSoyad = employee.AdSoyad;
            existingEmployee.Astlar = employee.Astlar;
            existingEmployee.Ust = employee.Ust;

            _repository.UpdateEmployee(existingEmployee);
            _repository.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            var existingEmployee=_repository.GetEmployeeById(id);
            if (existingEmployee == null)
                return BadRequest();

            _repository.DeleteEmployee(existingEmployee);
            _repository.SaveChanges();

            return Ok();
        }
    }
}
