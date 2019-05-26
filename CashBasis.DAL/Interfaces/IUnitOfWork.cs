using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CashBasis.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBillItemRepository BillItemRepository { get; }
        IBillRepository BillRepository { get; }
        IExpenseCategoryRepository ExpenseCategoryRepository { get; }
        IExpenseRepository ExpenseRepository { get; }
        IIncomeRepository IncomeRepository { get; }
        IRecurrenceRepository RecurrenceRepository { get; }

        int Commit();
        Task<int> CommitAsync();
    }
}
