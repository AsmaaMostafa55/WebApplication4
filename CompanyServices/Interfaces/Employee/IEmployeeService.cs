

using CompanyData.Entities;
using CompanyServices.Interfaces.DepartmentDto;
using CompanyServices.Interfaces.Employee.Dto;

namespace CompanyServices.Interfaces
{
    public interface IEmployeeService
    {
        EmployeeDto GetById(int? id);

        IEnumerable<EmployeeDto> GEtAll();
        void Add(EmployeeDto employee);
        void Update(EmployeeDto employee);
        void Delete(EmployeeDto employee);

      
        IEnumerable<EmployeeDto> GetEmployeeByName(string name);
    }
}
