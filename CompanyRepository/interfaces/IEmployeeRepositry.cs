using CompanyData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyRepository.interfaces
{
    public interface IEmployeeRepositry:IGenericRepositry<Employee>
    {

        //Employee GEtById(int id);
        //IEnumerable<Employee> GetAll();
        //void Add(Employee employee);
        //void Delete(Employee employee);
        //void Update(Employee employee);

        IEnumerable<Employee> GetEmployeeByName(string name);
        IEnumerable<Employee> GetEmployeeByddress(string address);
    }
}
