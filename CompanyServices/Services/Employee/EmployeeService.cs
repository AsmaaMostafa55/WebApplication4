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
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(Employee employee)
        {
            Employee employee = new Employee();
            {

            }
        }

        public void Delete(Employee employee)
        {
           _unitOfWork.EmployeeRepositry.Delete(employee);
            _unitOfWork.Complete();
        }

        public IEnumerable<Employee> GEtAll()
        {
            var employess=_unitOfWork.EmployeeRepositry.GetAll();
            return employess;
        }

        public Employee GetById(int? id)
        {if(id == null)
                return null;
            var employee = _unitOfWork.EmployeeRepositry.GetbyId(id.Value);
            if(employee == null)
                return null;
            return employee;
        }

        public IEnumerable<Employee> GetEmployeeByName(string name)
        =>  _unitOfWork.EmployeeRepositry.GetEmployeeByName(name);
        

        public void Update(Employee employee)
        {
           _unitOfWork.EmployeeRepositry.Update(employee);
            _unitOfWork.Complete();
        }
    }
}
