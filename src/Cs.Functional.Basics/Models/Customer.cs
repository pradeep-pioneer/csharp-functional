using System;
namespace Cs.Functional.Basics.Models
{
    public class Customer
    {
        public int? CustomerId { get; set; }
        public string Name { get; set; }
        public LoyalityProfile LoyalityProfile { get; set; }
    }
}
