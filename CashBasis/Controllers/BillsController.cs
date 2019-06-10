using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CashBasis.BusinessModel.Dtos;
using CashBasis.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CashBasis.Controllers
{
    public class BillsController : BaseController
    {
        private readonly IBillService _billService;

        public BillsController(IBillService billService)
        {
            _billService = billService;
        }
        // GET api/values
        [HttpGet]
        //[Route("api/[controller]/[action]")]
        public async Task<ActionResult<IEnumerable<BillDto>>> GetBills(int pageNumber, int pageSize)
        {
            return await _billService.GetAllBills(pageNumber, pageSize);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<BillDto> GetBillById(int id)
        {
            return _billService.GetBillById(id);
        }

        // POST api/values
        [HttpPost]
        public void CreateBill([FromBody] BillCreateUpdateDto item)
        {
            _billService.CreateBill(item);
        }
        // POST api/values
        [HttpPost]
        public void AddBillItem([FromBody] BillItemsDto item)
        {
            _billService.CreateBillItem(item);
        }
        // PUT api/values/5
        [HttpPut("{id}")]
        public void UpdateBillItem(int id, [FromBody] BillItemsDto item)
        {
            _billService.UpdateBillItem(id, item);
        }
        // PUT api/values/5
        [HttpPut("{id}")]
        public void UpdateBill(int id, [FromBody] BillCreateUpdateDto item)
        {
            _billService.UpdateBill(id, item);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void DeleteBill(int id)
        {
            _billService.RemoveBill(id);
        }
    }
}
