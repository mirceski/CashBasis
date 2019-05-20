using System;
using System.Collections.Generic;

namespace CB.Entities
{
    public class Bill
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Vendor { get; set; }
        public ExpenseCategory Category { get; set; }
        public Recurrence Recurrence { get; set; }
        public ICollection<Billitem> BillItems { get; set; }
        public DateTime DueDate { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
