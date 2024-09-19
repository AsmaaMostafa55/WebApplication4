using AutoMapper;
using CompanyServices.Interfaces.Department.Dto;

using CompanyData.Entities;



namespace CompanyServices.Mapping.Departments
{
    public  class DepartmentProfile:Profile
    {
		CreateMap<Department, DepartmentDto>().ReverseMap();



    }
}
