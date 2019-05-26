using CashBasis.DAL.Implementation;
using CashBasis.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashBasis.DAL.Interfaces
{
    public class IncomeRepository : BaseRepository<Income>, IIncomeRepository
    {
        public IncomeRepository(CBContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<Income>();
        }

        public IQueryable<Income> GetIncomesWithRecurrences()
        {
            return _dbSet.Include(x => x.Recurrence);
        }

        public Income GetIncomeWithRecurrenceById(int Id)
        {
            return _dbSet.Include(x => x.Recurrence).SingleOrDefault(x => x.IncomeId == Id);
        }
    }
}
