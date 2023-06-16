using AutoMapper;
using Employees.Models;
using Employees.Dtos;

namespace Employees.Profiles
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee,EmployeeReadDto>();
            CreateMap<EmployeeCreateDto,Employee>();
            CreateMap<EmployeeUpdateDto,Employee>();
            CreateMap<Employee,EmployeeUpdateDto>();
        }
    }
}
