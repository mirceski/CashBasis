using CashBasis.BusinessModel.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashBasis.Services.Interfaces
{
    public interface IExpenseCategoryService
    {
        List<ExpenseCategoryDto> GetAllExpenseCategories();
        ExpenseCategoryDto GetExpenseCategoryById(int id);
        ExpenseCategoryDto CreateExpenseCategory(ExpenseCategoryDto item);
        ExpenseCategoryDto UpdateExpenseCategory(int id, ExpenseCategoryDto item);
        void RemoveExpenseCategory(int id);
    }
}
