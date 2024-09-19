using CompanyData.Contexts;
using CompanyData.Entities;
using CompanyRepository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyRepository.Repositries
{
    public class Employeerepositry : GenericRepositry<Employee>, IEmployeeRepositry
    {
        private readonly CompanyDbContexts _context;

        public CompanyDbContexts Contexts { get; set; }

        public Employeerepositry(CompanyDbContexts context) : base(context)
        {
            {
                _context = context;
            }
            //public void Add(Employee employee)
            //{
            //   _context.Add(employee);
            //}

            //public void Delete(Employee employee)
            //{
            //    _context.Remove(employee);
            //}

            //public IEnumerable<Employee> GetAll()=>

            //    _context.Employees.ToList();   


            //public Employee GEtById(int id)=>

            //    _context.Employees.FirstOrDefault(x=>x.id==id);


            //public void Update(Employee employee)=>
            //    _context.Update(employee);

        }

        public IEnumerable<Employee>  GetEmployeeByName(string name)
      => _context.Employees.Where(x => 
      x.name.Trim().ToLower().Contains(name.Trim().ToLower())||
      x.phonenumber.Trim().ToLower().Contains(name.Trim().ToLower())
      ).ToList();

        public IEnumerable<Employee> GetEmployeeByddress(string address)
        {
            throw new NotImplementedException();
        }
    }
}