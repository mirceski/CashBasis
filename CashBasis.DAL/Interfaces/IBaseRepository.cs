using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashBasis.DAL.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        T FindById(int Id);

        T Add(T entity); 

        T Update(int id, T newEntity);

        T Delete(int Id);
    }
}
