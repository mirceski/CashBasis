using CashBasis.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CashBasis.DAL.Interfaces
{
    public interface IExpenseRepository : IBaseRepository<Expense>
    {
        IQueryable<Expense> GetExpensesWithCategories();
        Expense GetExpenseWithCategoryById(int Id);
    }
}
