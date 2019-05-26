using CashBasis.BusinessModel.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashBasis.Services.Interfaces
{
    public interface IExpenseService
    {
        List<ExpenseDto> GetAllExpenses(int pageNumber, int pageSize = 10);
        ExpenseDto GetExpenseById(int id);
        ExpenseDto CreateExpense(ExpenseDto item);
        ExpenseDto UpdateExpense(int id, ExpenseDto item);
        void RemoveExpense(int id);
    }
}
