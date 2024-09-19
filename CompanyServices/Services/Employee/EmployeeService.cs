using CompanyRepository.interfaces;
using CompanyServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyData.Entities;
using CompanyServices.Interfaces.Department.Dto;
using CompanyServices.Interfaces.Employee.Dto;
using System.Net.Sockets;
using System.Net;
using AutoMapper;

namespace CompanyServices.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public EmployeeService(IUnitOfWork unitOfWork,IMapper mapper )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Add(EmployeeDto employeeDto)
        {//manual mapping
         //Employee employee = new Employee
         //{
         //    address = employeeDto.address,
         //        age= employeeDto.age,
         //        DepartmentId = employeeDto.DepartmentId,
         //        hiringdate= employeeDto.hiringdate,
         //        name= employeeDto.name,
         //        phonenumber= employeeDto.phonenumber,
         //        salary= employeeDto.salary

            //};
            employeeDto.ImageUrl = DocumentSettings.UploadFile(employeeDto.Image, "Images");
            Employee employee = _mapper.Map<Employee>(employeeDto);
            _unitOfWork.EmployeeRepositry.Add(employee);
            _unitOfWork.Complete();

        }

        public void Delete(EmployeeDto employeeDto)
        {
            //Employee employee = new Employee
            //{
            //    address = employeeDto.address,
            //    age = employeeDto.age,
            //    DepartmentId = employeeDto.DepartmentId,
            //    hiringdate = employeeDto.hiringdate,
            //    name = employeeDto.name,
            //    phonenumber = employeeDto.phonenumber,
            //    salary = employeeDto.salary

            //};
            Employee employee = _mapper.Map<Employee>(employeeDto);
            _unitOfWork.EmployeeRepositry.Delete(employee);
            _unitOfWork.Complete();
        }

        public IEnumerable<EmployeeDto> GEtAll()
        {
            var employess=_unitOfWork.EmployeeRepositry.GetAll();


            //var mappedEmployees = employess.Select(x => new EmployeeDto
            //{
            //    DepartmentId= x.DepartmentId,
            //    hiringdate= x.hiringdate,
            //    imageurl= x.imageurl,
            //    name = x.name,
            //    phonenumber= x.phonenumber,
            //    salary= x.salary,
            //    id= x.id,
            //    address= x.address,
            //    age= x.age,
            //    createat=x.createdat,

            //});
         IEnumerable  < EmployeeDto> mappedEmployees = _mapper.Map<IEnumerable<EmployeeDto>>(employess);
            return mappedEmployees;
        }

        public EmployeeDto GetById(int? id)
        {if(id == null)
                return null;
            var employee = _unitOfWork.EmployeeRepositry.GetbyId(id.Value);
            if(employee == null)
                return null;
            //EmployeeDto employeeDto = new EmployeeDto
            //{
            //    address = employee.address,
            //    age = employee.age,
            //    DepartmentId = employee.DepartmentId,
            //    hiringdate = employee.hiringdate,
            //    name = employee.name,
            //    phonenumber = employee.phonenumber,
            //    salary = employee.salary,
            //    id= employee.id,
            //    createat = employee.createdat,


            //};
            EmployeeDto employeeDto = _mapper.Map<EmployeeDto>(employee);
            return employeeDto;
        }

        public IEnumerable<EmployeeDto> GetEmployeeByName(string name)
        {
         var employees= _unitOfWork.EmployeeRepositry.GetEmployeeByName(name);
            //var mappedEmployees = employees.Select(x => new EmployeeDto
            //{
            //    DepartmentId = x.DepartmentId,
            //    hiringdate = x.hiringdate,
            //    imageurl = x.imageurl,
            //    name = x.name,
            //    phonenumber = x.phonenumber,
            //    salary = x.salary,
            //    id = x.id,
            //    address = x.address,
            //    age = x.age,
            //    createat = x.createdat,

            //});
            IEnumerable<EmployeeDto> mappedEmployees = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return mappedEmployees;

        }


          
        

        public void Update(EmployeeDto employee)
        {
          // _unitOfWork.EmployeeRepositry.Update(employee);
            _unitOfWork.Complete();
        }
    }
}
