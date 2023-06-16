using AutoMapper;
using Calisanlar.Data;
using Employees.Dtos;
using Employees.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Employees.controller
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController:ControllerBase
    {
        private IEmployeeRepo _repository;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepo repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        private EmployeeReadDto GetEmployeeTree(EmployeeReadDto employeeReadDto)
        {
            var tree = new EmployeeReadDto
            {
                Id = employeeReadDto.Id,
                AdSoyad = employeeReadDto.AdSoyad,
                SicilNo = employeeReadDto.SicilNo,
                Astlar = new List<EmployeeReadDto>()
            };

            if (employeeReadDto.Astlar != null)
            {
                foreach (var ast in employeeReadDto.Astlar)
                {
                    var astTree = GetEmployeeTree(ast);
                    tree.Astlar.Add(astTree);
                }
            }

            return tree;
        }



        [HttpGet]
        public ActionResult<IEnumerable<EmployeeReadDto>> GetAllEmployees()
        {
            var rootEmployees = _repository.GetAllEmployees().ToList();
            var employeeTree = new List<EmployeeReadDto>();
            foreach (var employee in rootEmployees)
            {
                var employeeReadDto = _mapper.Map<EmployeeReadDto>(employee);
                var tree = GetEmployeeTree(employeeReadDto);
                employeeTree.Add(tree);

            }

            return Ok(employeeTree);
        }

        //[HttpPost]
        //public ActionResult<EmployeeCreateDto> CreateEmployee (EmployeeCreateDto employeeCreateDto)
        //{
        //    var employeeModel=_mapper.Map<Employee>(employeeCreateDto);
        //    if (!ModelState.IsValid)
        //        return BadRequest("Invalid data");

        //    if (employeeModel.SicilNo.Length != 11 || !employeeModel.SicilNo.All(char.IsLetterOrDigit))
        //        return BadRequest("Invalid Sicil No");

        //    _repository.CreateEmployee(employeeModel);
        //    _repository.SaveChanges();

        //    var employeeReadDto=_mapper.Map<EmployeeReadDto>(employeeModel);

        //    return Ok(employeeReadDto);
        //}

        [HttpPost]
        public ActionResult<EmployeeReadDto> CreateEmployee(EmployeeCreateDto employeeCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");

            if (employeeCreateDto.SicilNo.Length != 11 || !employeeCreateDto.SicilNo.All(char.IsLetterOrDigit))
                return BadRequest("Invalid Sicil No");

            var employeeModel = _mapper.Map<Employee>(employeeCreateDto);
            _repository.CreateEmployee(employeeModel);
            _repository.SaveChanges();

            var employeeReadDto = _mapper.Map<EmployeeReadDto>(employeeModel);

            return Ok(employeeReadDto);
        }




        [HttpPut("{id}")]
        public ActionResult UpdateEmployee(int id, EmployeeUpdateDto employeeUpdateDto) 
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");


            var existingEmployee=_repository.GetEmployeeById(id);
            if (existingEmployee == null)
                return BadRequest();

            //existingEmployee.AdSoyad = employee.AdSoyad;
            //existingEmployee.Astlar = employee.Astlar;
            //existingEmployee.Ust = employee.Ust;


            _mapper.Map(employeeUpdateDto, existingEmployee);
            _repository.UpdateEmployee(existingEmployee);
            _repository.SaveChanges();

            return NoContent();
        }

        //[HttpDelete("{id}")]
        //public ActionResult DeleteEmployee(int id)
        //{
        //    var existingEmployee=_repository.GetEmployeeById(id);
        //    if (existingEmployee == null)
        //        return BadRequest();

        //    _repository.DeleteEmployee(existingEmployee);
        //    _repository.SaveChanges();

        //    return Ok();
        //}
    }
}
