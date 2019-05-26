using AutoMapper;
using CashBasis.BusinessModel.Dtos;
using CashBasis.DAL.Interfaces;
using CashBasis.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
            throw new NotImplementedException();
        }

        public List<IncomeDto> GetAllIncomes(int pageNumber, int pageSize = 10)
        {
            throw new NotImplementedException();
        }

        public IncomeDto GetIncomeById(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveIncome(int id)
        {
            throw new NotImplementedException();
        }

        public IncomeDto UpdateIncome(int id, IncomeDto item)
        {
            throw new NotImplementedException();
        }
    }
}
