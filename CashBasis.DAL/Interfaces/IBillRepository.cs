using CashBasis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashBasis.DAL.Interfaces
{
    public interface IBillRepository : IBaseRepository<Bill>
    {
        IQueryable<Bill> GetAllBillsWithRelatedEntities();
        Bill GetBillWithRelatedEntitiesById(int id);
    }
}
