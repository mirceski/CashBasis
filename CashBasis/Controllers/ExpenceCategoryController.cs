using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CashBasis.BusinessModel.Dtos;
using CashBasis.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CashBasis.Controllers
{
    public class ExpenceCategoryController : BaseController
    {
        private readonly IExpenseCategoryService _expenseCategoryService;

        public ExpenceCategoryController(IExpenseCategoryService expenseCategoryService)
        {
            _expenseCategoryService = expenseCategoryService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<ExpenseCategoryDto>> GetExpenseCategories()
        {
            return _expenseCategoryService.GetAllExpenseCategories();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<ExpenseCategoryDto> GetExpenseCategoryById(int id)
        {
            return _expenseCategoryService.GetExpenseCategoryById(id);
        }

        // POST api/values
        [HttpPost]
        public void CreateExpenseCategory([FromBody] ExpenseCategoryDto item)
        {
            _expenseCategoryService.CreateExpenseCategory(item);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void UpdateExpenseCategory(int id, [FromBody] ExpenseCategoryDto item)
        {
            _expenseCategoryService.UpdateExpenseCategory(id, item);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void DeleteExpenseCategory(int id)
        {
            _expenseCategoryService.RemoveExpenseCategory(id);
        }
    }
}
