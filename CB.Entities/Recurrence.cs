using System;
using System.Collections.Generic;
using System.Text;

namespace CashBasis.Entities
{
    public class Recurrence
    {
        public int RecurrenceId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        public Bill Bill { get; set; }
        public Income Income { get; set; }
    }
}
