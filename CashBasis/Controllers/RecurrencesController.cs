using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CashBasis.BusinessModel.Dtos;
using CashBasis.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CashBasis.Controllers
{
    public class RecurrencesController : BaseController
    {
        private readonly IRecurrenceService _recurrenceService;

        public RecurrencesController(IRecurrenceService recurrenceService)
        {
            _recurrenceService = recurrenceService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<RecurrenceDto>> GetRecurrences()
        {
            return _recurrenceService.GetAllRecurrences();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<RecurrenceDto> GetRecurrenceById(int id)
        {
            return _recurrenceService.GetRecurrenceById(id);
        }

        // POST api/values
        [HttpPost]
        public void CreateRecurrence([FromBody] RecurrenceDto item)
        {
            _recurrenceService.CreateRecurrence(item);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void UpdateRecurrence(int id, [FromBody] RecurrenceDto item)
        {
            _recurrenceService.UpdateRecurrence(id, item);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void DeleteRecurrence(int id)
        {
            _recurrenceService.RemoveRecurrence(id);
        }
    }
}
