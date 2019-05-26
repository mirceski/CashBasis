using AutoMapper;
using CashBasis.BusinessModel.Dtos;
using CashBasis.DAL.Interfaces;
using CashBasis.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashBasis.Services.Implementation
{
    public class RecurrenceService : IRecurrenceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RecurrenceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public RecurrenceDto CreateRecurrence(RecurrenceDto item)
        {
            throw new NotImplementedException();
        }

        public List<RecurrenceDto> GetAllRecurrences(int pageNumber, int pageSize = 10)
        {
            throw new NotImplementedException();
        }

        public RecurrenceDto GetRecurrenceById(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveRecurrence(int id)
        {
            throw new NotImplementedException();
        }

        public RecurrenceDto UpdateRecurrence(int id, RecurrenceDto item)
        {
            throw new NotImplementedException();
        }
    }
}
