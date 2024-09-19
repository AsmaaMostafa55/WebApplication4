using AutoMapper;
using CompanyData.Entities;
using CompanyServices.Interfaces.Employee.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyServices.Mapping
{
    public class EmployeeProfile :Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
          //  CreateMap<EmployeeDto, Employee>();
        }
    }
}
