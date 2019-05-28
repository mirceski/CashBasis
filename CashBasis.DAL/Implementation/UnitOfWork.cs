using CashBasis.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CashBasis.DAL.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        public CBContext _context;
        public IBillItemRepository BillItemRepository { get; private set; }
        public IBillRepository BillRepository { get; private set; }
        public IExpenseCategoryRepository ExpenseCategoryRepository { get; private set; }
        public IExpenseRepository ExpenseRepository { get; private set; }
        public IIncomeRepository IncomeRepository { get; private set; }
        public IRecurrenceRepository RecurrenceRepository { get; private set; }

        public UnitOfWork(CBContext context,
            IBillItemRepository billItemRepository,
            IBillRepository billRepository,
            IExpenseCategoryRepository expenseCategoryRepository,
            IExpenseRepository expenseRepository,
            IIncomeRepository incomeRepository,
            IRecurrenceRepository recurrenceRepository)
        {
            _context = context;
            BillItemRepository = billItemRepository;
            BillRepository = billRepository;
            ExpenseCategoryRepository = expenseCategoryRepository;
            ExpenseRepository = expenseRepository;
            IncomeRepository = incomeRepository;
            RecurrenceRepository = recurrenceRepository;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
