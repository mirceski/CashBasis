using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashBasis.BusinessModel.Dtos
{
    public class IncomeDto
    {
        [JsonIgnore]
        public int IncomeId { get; set; }
        public int? RecurrenceId { get; set; }
        public string Company { get; set; }
        public decimal NetAmount { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public RecurrenceDto Recurrence { get; set; }
    }
}
