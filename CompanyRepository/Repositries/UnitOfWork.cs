using CompanyData.Contexts;
using CompanyRepository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyRepository.Repositries
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CompanyDbContexts _context;
        public UnitOfWork(CompanyDbContexts context)
        {
            _context = context;
            DepartmentRepositry = new DepartmentRepositry(context);
            EmployeeRepositry=new Employeerepositry(context);           
        }

        public IDepartmentRepositry DepartmentRepositry { get ; set; }
        public IEmployeeRepositry EmployeeRepositry { get ; set; }

        public int Complete()
         =>_context.SaveChanges();
        
    }
}
