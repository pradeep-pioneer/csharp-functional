using System;
using System.Collections.Generic;
using System.Linq;
using Cs.Functional.Basics.Models;

namespace Cs.Functional.Basics
{
    public static class FunctionalPatterns
    {
        // Problem 1: Monads and functional extensions available in Linq
        public static IEnumerable<Customer> CalculateCustomerLoyalityProfile(IEnumerable<ShoppingCart> shoppingCarts)
        {
            /*
             * Given a list of shopping carts we have to calculate loyality profile of each customer. The logic defined for this is as follows:
             * 1. Exclude all unsigned customer, the cart will have a customer object that will have customer id as null.
             * 2. For all customers the Loyality points for each purchase will be => TotalPurchaseValue X (1/10) X CustomerLevel (0,1,2,3,4,5)
             * Example: For a purchase value of 5000:
             *  A. Basic Customer Will Earn: 5000 X (1/10) X 1
             *  B. Silver Customer Earns:5000 X (1/10) X 1
             *  C. Gold Customer Earns: 5000 X (1/10) X 2... and so on
             * 3. The final list of customers returned will have updated customer profile such that:
             *  A. LoyalityPoints will be (previous LoyalityPoints + LoyalityPoints earned in the current cart)
             *  B. CustomerLevel is calculated as follows:
             *      B.1 Basic: 0-2000 Points
             *      B.2 Silver: 2000-5000 Points
             *      B.3 Gold: 5000-10000 Points
             *      B.4 Diamond: 10000-20000 Points
             *      B.5 Platinum: 20000 Points and More
             */
            return null;
        }

        // Problem 2: Some More Monads and Aggregation Examples
        public static IGrouping<CustomerLevel, Customer> GetTopCustomersInEachCategory(IEnumerable<Customer> customers)
        {
            /*
             * Given a collection of customers return the top customers (with highest points) in each category (Basic,Silver,Gold, Diamond, Platinum)
             */
            return null;
        }

        //Problem 3: Partial Function Application
        /*
         * Assuming that we cannot modify the above logic for points calculation, we have a black friday sale coming and we would to change the logic for point allocations such that:
         * Not all products sold in the black friday sale earn points and some products earn twice the points for all customer categories.
         */
    }
}
