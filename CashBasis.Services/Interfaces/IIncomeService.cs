using CashBasis.BusinessModel.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashBasis.Services.Interfaces
{
    public interface IIncomeService
    {
        List<IncomeDto> GetAllIncomes(int pageNumber, int pageSize = 10);
        IncomeDto GetIncomeById(int id);
        IncomeDto CreateIncome(IncomeDto item);
        IncomeDto UpdateIncome(int id, IncomeDto item);
        void RemoveIncome(int id);
    }
}
