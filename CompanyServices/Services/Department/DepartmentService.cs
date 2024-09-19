using CompanyRepository.interfaces;
using CompanyServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyData.Entities;
using CompanyServices.Interfaces.Department.Dto;
using AutoMapper;

namespace CompanyServices.Services
{
    public class DepartmentService : IDepartmentService
    {
      //  private readonly IDepartmentRepositry _departmentRepositry;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DepartmentService(IUnitOfWork unitOfWork ,IMapper mapper )
        {
         //   _departmentRepositry = departmentRepositry;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(DepartmentDto departmentDto)
        {
            //var mappedDepartment = new DepartmentDto
            //{
            //    code = department.code,
            //    name = department.name,
            //    //createat = DateTime.Now,
            //};

            var mappedDepartment=_mapper.Map<Department>(departmentDto);



            _unitOfWork.DepartmentRepositry.Add(mappedDepartment);
            _unitOfWork.Complete();
        }

      

        //public void Add(CompanyData.Entities.Department department)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Add(CompanyData.Entities.Department department)
        //{
        //    var mappedDepartment = new Department
        //    {
        //        code = department.code,
        //        name = department.name,
        //        createat = DateTime.Now
        //    };
        //    _departmentRepositry.Add(mappedDepartment);
        //}

        public void Delete(DepartmentDto departmentDto)
        {
            var mappedDepartment = _mapper.Map<Department>(departmentDto);
            _unitOfWork.DepartmentRepositry.Delete(mappedDepartment);
            _unitOfWork.Complete();
        }

        //public void Delete(DepartmentDto department)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<DepartmentDto> GetAll()
        {
         var departments= _unitOfWork.DepartmentRepositry.GetAll();
            var mappedDepartments=_mapper.Map<IEnumerable<DepartmentDto>>(departments);
            return mappedDepartments;
        }

        public DepartmentDto GetById(int? id)
        {
            if (id is null)
                return null;
            var department = _unitOfWork.DepartmentRepositry.GetbyId(id.Value);
            if (department is null)
            
                return null;
            var mappedDepartments = _mapper.Map<DepartmentDto>(department);
            return mappedDepartments;
        }

        public void Update(DepartmentDto department)
        {
            //var dept=GetById(department.id);
            //if(dept.name !=department.name)
            //{
            //    if (GetAll().Any(x => x.name == department.name))
            //        throw new Exception("DuplicateDepartmentName");
            //}
            //dept.name = department.name;
            //dept.code = department.code;
            //_unitOfWork.DepartmentRepositry.Update(department);
            //_unitOfWork.Complete();
          
        }

       
    }
}
