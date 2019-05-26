using System;
using System.Collections.Generic;
using System.Text;

namespace CashBasis.Entities
{
    public class Income
    {
        public int IncomeId { get; set; }
        public int? RecurrenceId { get; set; }
        public string Company { get; set; }
        public decimal NetAmount { get; set; }
        public DateTime? StartDate { get; set; }

        public Recurrence Recurrence { get; set; }
    }
}
