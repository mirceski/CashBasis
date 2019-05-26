using System;
using System.Collections.Generic;

namespace CashBasis.Entities
{
    public class Bill
    {
        public Bill()
        {
            BillItems = new HashSet<BillItem>();
        }
        public int BillId { get; set; }
        public int CategoryId { get; set; }
        public int? RecurrenceId { get; set; }
        public string Description { get; set; }
        public string Vendor { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime? DateCreated { get; set; }

        public ExpenseCategory Category { get; set; }
        public Recurrence Recurrence { get; set; }
        public ICollection<BillItem> BillItems { get; private set; }
    }
}
