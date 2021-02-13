using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerGateway.Model
{
    public class CustomerRating
    {
        public CustomerRating(
            int customerId,
            int customerRate,
            string description)
        {
            CustomerId = customerId;
            CustomerRate = customerRate;
            Description = description;
        }

        public int CustomerId { get; }

        public int CustomerRate { get; }

        public string Description { get; }
    }
}
