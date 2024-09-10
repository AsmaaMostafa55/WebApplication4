using CompanyData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyRepository.interfaces
{
    public interface IGenericRepositry< T> where T : BaseEntity
    {
        T GetbyId(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);

        void Update(T entity);
        void Delete(T entity);
    }
}
