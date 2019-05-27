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
    public class IncomeService : IIncomeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public IncomeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IncomeDto CreateIncome(IncomeDto item)
        {
            var entityIncome = _mapper.Map<Income>(item);

            var newIncomeItem = _unitOfWork.IncomeRepository.Add(entityIncome);
            _unitOfWork.Commit();

            return _mapper.Map<IncomeDto>(newIncomeItem);
        }

        public List<IncomeDto> GetAllIncomes(int pageNumber, int pageSize = 10)
        {
            var allIncomes = _unitOfWork.IncomeRepository.GetIncomesWithRecurrences();

            var sortedIncomes = allIncomes.OrderBy(c => c.StartDate)
                                        .Skip((pageNumber - 1) * pageSize)
                                        .Take(pageSize)
                                        .ToList();
            return _mapper.Map<List<IncomeDto>>(sortedIncomes);
        }

        public IncomeDto GetIncomeById(int id)
        {
            var income = _unitOfWork.IncomeRepository.GetIncomeWithRecurrenceById(id);
            return _mapper.Map<IncomeDto>(income);
        }

        public void RemoveIncome(int id)
        {
            _unitOfWork.IncomeRepository.Delete(id);
            _unitOfWork.Commit();
        }

        public IncomeDto UpdateIncome(int id, IncomeDto item)
        {
            var entityIncome = _mapper.Map<Income>(item);
            var existingIncome = _unitOfWork.IncomeRepository.FindById(entityIncome.IncomeId);

            if (existingIncome != null)
            {
                var newIncome = _unitOfWork.IncomeRepository.Update(id, entityIncome);
                return _mapper.Map<IncomeDto>(newIncome);
            }
            else
            {
                return CreateIncome(item);
            }
        }
    }
}
