﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Naspinski.FoodTruck.Data.Access.AdditionalModels
{

    public class PriceAndQuantity
    {
        public int PriceId { get; set; }
        public int Quantity { get; set; }
        public IEnumerable<string> ComboParts { get; set; }
    }
}