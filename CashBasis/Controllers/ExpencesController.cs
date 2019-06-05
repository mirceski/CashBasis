using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CashBasis.BusinessModel.Dtos;
using CashBasis.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CashBasis.Controllers
{
    public class ExpencesController : BaseController
    {
        private readonly IExpenseService _expenseService;

        public ExpencesController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<ExpenseDto>> GetExpenses(int pageNumber, int pageSize)
        {
            return _expenseService.GetAllExpenses(pageNumber, pageSize);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<ExpenseDto> GetExpenseById(int id)
        {
            return _expenseService.GetExpenseById(id);
        }

        // POST api/values
        [HttpPost]
        public void CreateExpense([FromBody] ExpenseDto item)
        {
            _expenseService.CreateExpense(item);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void UpdateExpense(int id, [FromBody] ExpenseDto item)
        {
            _expenseService.UpdateExpense(id, item);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void DeleteExpense(int id)
        {
            _expenseService.RemoveExpense(id);
        }
    }
}
