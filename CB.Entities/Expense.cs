using System;
using System.Collections.Generic;
using System.Text;

namespace CB.Entities
{
    public class Expense
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Payee { get; set; }
        public ExpenseCategory Category { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
