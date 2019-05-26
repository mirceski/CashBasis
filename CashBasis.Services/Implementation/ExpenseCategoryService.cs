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
    public class ExpenseCategoryService : IExpenseCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExpenseCategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ExpenseCategoryDto CreateExpenseCategory(ExpenseCategoryDto item)
        {
            var entityExpenseCategory = _mapper.Map<ExpenseCategory>(item);

            var newExpenseCategoryItem = _unitOfWork.ExpenseCategoryRepository.Add(entityExpenseCategory);
            _unitOfWork.Commit();
             
            return _mapper.Map<ExpenseCategoryDto>(newExpenseCategoryItem);
        }

        public List<ExpenseCategoryDto> GetAllExpenseCategories()
        {
            var allExpenceCategories = _unitOfWork.ExpenseCategoryRepository.GetAll().ToList();
            return _mapper.Map<List<ExpenseCategoryDto>>(allExpenceCategories);
        }

        public ExpenseCategoryDto GetExpenseCategoryById(int id)
        {
            var allExpenceCategories = _unitOfWork.ExpenseCategoryRepository.FindById(id);
            return _mapper.Map<ExpenseCategoryDto>(allExpenceCategories);
        }
        
        public void RemoveExpenseCategory(int id)
        {
            _unitOfWork.ExpenseCategoryRepository.Delete(id);
            _unitOfWork.Commit();
        }

        public ExpenseCategoryDto UpdateExpenseCategory(int id, ExpenseCategoryDto item)
        {
            var entityExpenseCategory = _mapper.Map<ExpenseCategory>(item);
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
