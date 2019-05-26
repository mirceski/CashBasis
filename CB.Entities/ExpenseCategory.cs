using System;
using System.Collections.Generic;
using System.Text;

namespace CashBasis.Entities
{
    public class ExpenseCategory
    {
        public int ExpenseCategoryId { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

        public Bill Bill { get; set; }
        public Expense Expense { get; set; }
    }
}
