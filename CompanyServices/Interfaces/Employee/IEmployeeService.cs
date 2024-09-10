

using CompanyData.Entities;
using CompanyServices.Interfaces.DepartmentDto;

namespace CompanyServices.Interfaces
{
    public interface IEmployeeService
    {
        Employee GetById(int? id);

        IEnumerable<Employee> GEtAll();
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);

      
        IEnumerable<Employee> GetEmployeeByName(string name);
    }
}
