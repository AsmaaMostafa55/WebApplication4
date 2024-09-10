using CompanyData.Contexts;
using CompanyData.Entities;
using CompanyRepository.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyRepository.Repositries
{
    public class GenericRepositry<T> : IGenericRepositry<T> where T : BaseEntity
    {
        private readonly CompanyDbContexts _context;
        public GenericRepositry(CompanyDbContexts context)
        {
            _context= context;
        }
        public void Add(T entity)
         => _context.Set<T>().Add(entity);
     
        
        public void Delete(T entity)
            =>_context.Set<T>().Remove(entity);
          
        
      
        public IEnumerable<T> GetAll()
       => _context.Set<T>().ToList();

        public T GetbyId(int id)
        => _context.Set<T>().Find(id);
        public void Update(T entity)
        => _context.Set<T>().Update(entity);
    }
}
