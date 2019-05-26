using System;
using System.Collections.Generic;
using System.Text;

namespace CashBasis.BusinessModel.Dtos
{
    public class BillItemsDto
    {
        public int BillItemId { get; set; }
        public int BillId { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
    }
}
