using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CashBasis.BusinessModel.Dtos;
using CashBasis.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CashBasis.Controllers
{
    public class IncomesController : BaseController
    {
        private readonly IIncomeService _incomeService;

        public IncomesController(IIncomeService incomeService)
        {
            _incomeService = incomeService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<IncomeDto>> GetIncomes(int pageNumber, int pageSize)
        {
            return _incomeService.GetAllIncomes(pageNumber, pageSize);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<IncomeDto> GetIncomeById(int id)
        {
            return _incomeService.GetIncomeById(id);
        }

        // POST api/values
        [HttpPost]
        public void CreateIncome([FromBody] IncomeDto item)
        {
            _incomeService.CreateIncome(item);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void UpdateIncome(int id, [FromBody] IncomeDto item)
        {
            _incomeService.UpdateIncome(id, item);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void DeleteIncome(int id)
        {
            _incomeService.RemoveIncome(id);
        }
    }
}
