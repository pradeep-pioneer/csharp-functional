using System;
using System.Collections.Generic;

namespace Cs.Functional.Basics.Models
{
    public class ShoppingCart
    {
        public Customer Customer { get; set; }
        public IEnumerable<CartProduct> Products { get; set; }
    }
}
