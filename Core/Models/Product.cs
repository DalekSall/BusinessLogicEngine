using Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class Product
    {
        public string name { get; set; }
        public ProductTypes productType { get; set; }
        public ProductSubTypes productSubType { get; set; }
    }
}
