using System;
using System.Collections.Generic;
using System.Text;

namespace CashBasis.BusinessModel.Dtos
{
    public class ExpenseCategoryDto
    {
        public int ExpenseCategoryId { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
    }
}
