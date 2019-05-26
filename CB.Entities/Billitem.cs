using System;
using System.Collections.Generic;
using System.Text;

namespace CashBasis.Entities
{
    public class BillItem
    {
        public int BillItemId { get; set; }
        public int BillId { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }

        public Bill Bill { get; set; }
    }
}
