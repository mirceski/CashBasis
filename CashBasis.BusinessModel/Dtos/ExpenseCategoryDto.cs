using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashBasis.BusinessModel.Dtos
{
    public class ExpenseCategoryDto
    {
        [JsonIgnore]
        public int ExpenseCategoryId { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
    }
}
