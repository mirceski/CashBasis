﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CB.Entities
{
    public class Billitem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
    }
}
