using AutoMapper;
using CashBasis.BusinessModel.Dtos;
using CashBasis.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashBasis.Services.Mappings
{
    public class ServicesMapping : Profile
    {
        public ServicesMapping()
        {
            CreateMap<Bill, BillDto>();
            CreateMap<BillDto, Bill>();
            CreateMap<BillItem, BillItemsDto>();
            CreateMap<BillItemsDto, BillItem>();
            CreateMap<ExpenseCategory, ExpenseCategoryDto>();
            CreateMap<ExpenseCategoryDto, ExpenseCategory>()
                .ForMember(x => x.Bill, opt => opt.Ignore())
                .ForMember(x => x.Expense, opt => opt.Ignore());
            CreateMap<Expense, ExpenseDto>();
            CreateMap<ExpenseDto, Expense>();
            CreateMap<Income, IncomeDto>();
            CreateMap<IncomeDto, Income>();
            CreateMap<Recurrence, RecurrenceDto>();
            CreateMap<RecurrenceDto, Recurrence>();
        }
    }
}
