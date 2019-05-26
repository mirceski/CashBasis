using CashBasis.DAL.Implementation;
using CashBasis.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashBasis.DAL.Interfaces
{
    public class ExpenseRepository : BaseRepository<Expense>, IExpenseRepository
    {
        public ExpenseRepository(CBContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<Expense>();
        }

        public IQueryable<Expense> GetExpensesWithCategories()
        {
            return _dbSet.Include(x => x.Category);
        }

        public Expense GetExpenseWithCategoryById(int Id)
        {
            return _dbSet.Include(x => x.Category).SingleOrDefault(x => x.ExpenseId == Id);
        }
    }
}
