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
            var entityReccurence = _mapper.Map<Recurrence>(item);

            var newRecurrenceItem = _unitOfWork.RecurrenceRepository.Add(entityReccurence);
            _unitOfWork.Commit();

            return _mapper.Map<RecurrenceDto>(newRecurrenceItem);
        }

        public List<RecurrenceDto> GetAllRecurrences()
        {
            var allRecurrences = _unitOfWork.RecurrenceRepository.GetAll().ToList();
            return _mapper.Map<List<RecurrenceDto>>(allRecurrences);
        }

        public RecurrenceDto GetRecurrenceById(int id)
        {
            var recurrence = _unitOfWork.RecurrenceRepository.FindById(id);
            return _mapper.Map<RecurrenceDto>(recurrence);
        }

        public void RemoveRecurrence(int id)
        {
            _unitOfWork.RecurrenceRepository.Delete(id);
            _unitOfWork.Commit();
        }

        public RecurrenceDto UpdateRecurrence(int id, RecurrenceDto item)
        {
            var entityRecurrence = _mapper.Map<Recurrence>(item);
            var existingRecurrence = _unitOfWork.RecurrenceRepository.FindById(entityRecurrence.RecurrenceId);

            if (existingRecurrence != null)
            {
                var newRecurrence = _unitOfWork.RecurrenceRepository.Update(id, existingRecurrence);
                return _mapper.Map<RecurrenceDto>(newRecurrence);
            }
            else
            {
                return CreateRecurrence(item);
            }
        }
    }
}
