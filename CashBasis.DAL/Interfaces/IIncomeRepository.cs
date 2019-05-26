using CashBasis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashBasis.DAL.Interfaces
{
    public interface IIncomeRepository : IBaseRepository<Income>
    {
        IQueryable<Income> GetIncomesWithRecurrences();
        Income GetIncomeWithRecurrenceById(int Id);
    }
}
