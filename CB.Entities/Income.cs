using System;
using System.Collections.Generic;
using System.Text;

namespace CB.Entities
{
    public class Income
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public decimal NetAmount { get; set; }
        public DateTime StartDate { get; set; }
        public Recurrence Recurrence { get; set; }
    }
}
