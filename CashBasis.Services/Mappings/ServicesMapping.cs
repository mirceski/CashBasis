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
            CreateMap<Bill, BillCreateUpdateDto>();
            CreateMap<BillCreateUpdateDto, Bill>();
            CreateMap<BillItem, BillItemsDto>();
            CreateMap<BillItemsDto, BillItem>()
                .ForMember(x => x.Bill, opt => opt.Ignore());
            CreateMap<ExpenseCategoryDto, ExpenseCategory>()
                .ForMember(x => x.Bill, opt => opt.Ignore())
                .ForMember(x => x.Expense, opt => opt.Ignore());
            CreateMap<ExpenseCategory, ExpenseCategoryDto>();
            CreateMap<Expense, ExpenseDto>();
            CreateMap<ExpenseDto, Expense>();
            CreateMap<Income, IncomeDto>();
            CreateMap<IncomeDto, Income>();
            CreateMap<Recurrence, RecurrenceDto>();
            CreateMap<RecurrenceDto, Recurrence>()
                .ForMember(x => x.Bill, opt => opt.Ignore())
                .ForMember(x => x.Income, opt => opt.Ignore()); ;
        }
    }
}
