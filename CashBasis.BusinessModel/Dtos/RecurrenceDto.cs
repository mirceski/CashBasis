using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashBasis.BusinessModel.Dtos
{
    public class RecurrenceDto
    {
        [JsonIgnore]
        public int RecurrenceId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
}
