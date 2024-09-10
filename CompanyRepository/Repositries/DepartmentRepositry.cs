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
    public class DepartmentRepositry : GenericRepositry<Department>, IDepartmentRepositry
    {
        private readonly CompanyDbContexts _context;

        public CompanyDbContexts Contexts { get; set; }

        public DepartmentRepositry(CompanyDbContexts context) : base(context)
        {
            {
                _context = context;
            }
            //public void Add(Department department)
            //{
            //    _context.Add(department);
            //}

            //public void Delete(Department department)
            //{
            //    _context.Remove(department);
            //}

            //public IEnumerable<Department> GetAll() =>

            //    _context.Departments.ToList();


            //public Department GEtById(int id) =>

            //    _context.Departments.Find(id);


            //public void Update(Department department) =>
            //    _context.Update(department);

            //public Department GetbyId(int id)
            //{
            //    throw new NotImplementedException();
            //}
        }
    }
}
