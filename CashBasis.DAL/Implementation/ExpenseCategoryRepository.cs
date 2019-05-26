using CashBasis.DAL.Implementation;
using CashBasis.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashBasis.DAL.Interfaces
{
    public class ExpenseCategoryRepository : BaseRepository<ExpenseCategory>, IExpenseCategoryRepository
    {
        public ExpenseCategoryRepository(CBContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<ExpenseCategory>();
        }
    }
}
