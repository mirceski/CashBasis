using AutoMapper;
using CashBasis.BusinessModel.Dtos;
using CashBasis.DAL.Interfaces;
using CashBasis.Entities;
using CashBasis.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CashBasis.Services.Implementation
{
    public class ExpenseService : IExpenseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExpenseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ExpenseDto CreateExpense(ExpenseDto item)
        {
            var entityExpense = _mapper.Map<Expense>(item);

            var newExpenseItem = _unitOfWork.ExpenseRepository.Add(entityExpense);
            _unitOfWork.Commit();

            return _mapper.Map<ExpenseDto>(newExpenseItem);
        }

        public List<ExpenseDto> GetAllExpenses(int pageNumber, int pageSize = 10)
        {
            var allExpences = _unitOfWork.ExpenseRepository.GetExpensesWithCategories();

            var pagedExpenses = allExpences.OrderBy(c => c.DateCreated)
                                        .Skip((pageNumber - 1) * pageSize)
                                        .Take(pageSize)
                                        .ToList();
            return _mapper.Map<List<ExpenseDto>>(pagedExpenses);
        }

        public ExpenseDto GetExpenseById(int id)
        {
            var expense = _unitOfWork.ExpenseRepository.GetExpenseWithCategoryById(id);
            return _mapper.Map<ExpenseDto>(expense);
        }

        public void RemoveExpense(int id)
        {
            _unitOfWork.ExpenseRepository.Delete(id);
            _unitOfWork.Commit();
        }

        public ExpenseDto UpdateExpense(int id, ExpenseDto item)
        {
            var entityExpenseCategory = _mapper.Map<Expense>(item);
            var existingExpenseCategory = _unitOfWork.ExpenseCategoryRepository.FindById(entityExpenseCategory.ExpenseCategoryId);

            if (existingExpenseCategory != null)
            {
                var newExpenseCategory = _unitOfWork.ExpenseCategoryRepository.Update(id, entityExpenseCategory);
                return _mapper.Map<ExpenseCategoryDto>(newExpenseCategory);
            }
            else
            {
                return CreateExpenseCategory(item);
            }
        }
    }
}
