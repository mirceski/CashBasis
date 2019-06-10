using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashBasis.BusinessModel.Dtos
{
    public class ExpenseDto
    {
        [JsonIgnore]
        public int ExpenseId { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public string Payee { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime? DateCreated { get; set; }
        public ExpenseCategoryDto Category { get; set; }
    }
}
