using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashBasis.BusinessModel.Dtos
{
    public class BillDto
    {
        [JsonIgnore]
        public int BillId { get; set; }
        public int CategoryId { get; set; }
        public int? RecurrenceId { get; set; }
        public string Description { get; set; }
        public string Vendor { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime? DateCreated { get; set; }

        [JsonIgnore]
        public ExpenseCategoryDto Category { get; set; }
        [JsonIgnore]
        public RecurrenceDto Recurrence { get; set; }
        public List<BillItemsDto> BillItems { get; set; }
    }
}
