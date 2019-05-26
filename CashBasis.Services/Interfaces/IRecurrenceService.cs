using CashBasis.BusinessModel.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashBasis.Services.Interfaces
{
    public interface IRecurrenceService
    {
        List<RecurrenceDto> GetAllRecurrences(int pageNumber, int pageSize = 10);
        RecurrenceDto GetRecurrenceById(int id);
        RecurrenceDto CreateRecurrence(RecurrenceDto item);
        RecurrenceDto UpdateRecurrence(int id, RecurrenceDto item);
        void RemoveRecurrence(int id);
    }
}
