using CompanyRepository.interfaces;
using CompanyServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyData.Entities;
using CompanyServices.Interfaces.DepartmentDto;

namespace CompanyServices.Services
{
    public class DepartmentService : IDepartmentService
    {
      //  private readonly IDepartmentRepositry _departmentRepositry;
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork )
        {
         //   _departmentRepositry = departmentRepositry;
            _unitOfWork = unitOfWork;
        }

        public void Add(Department department)
        {
            var mappedDepartment = new Department
            {
                code = department.code,
                name = department.name,
                //createat = DateTime.Now,
            };
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

        public void Delete(Department department)
        {
            _unitOfWork.DepartmentRepositry.Delete(department);
            _unitOfWork.Complete();
        }

        public void Delete(DepartmentDto department)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Department> GetAll()
        {
         var departments= _unitOfWork.DepartmentRepositry.GetAll();
            return departments;
        }

        public Department GetById(int? id)
        {
            if (id is null)
                return null;
            var department = _unitOfWork.DepartmentRepositry.GetbyId(id.Value);
            if (department is null)
            
                return null;
            
            return department;
        }

        public void Update(Department department)
        {
            //var dept=GetById(department.id);
            //if(dept.name !=department.name)
            //{
            //    if (GetAll().Any(x => x.name == department.name))
            //        throw new Exception("DuplicateDepartmentName");
            //}
            //dept.name = department.name;
            //dept.code = department.code;
            _unitOfWork.DepartmentRepositry.Update(department);
            _unitOfWork.Complete();
          
        }

       
    }
}
