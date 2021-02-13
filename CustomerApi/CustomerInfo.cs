using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApi
{
    public class CustomerInfo
    {
        public CustomerInfo(
            int customerId,
            string customerName,
            string gender)
        {
            CustomerId = customerId;
            CustomerName = customerName;
            Gender = gender;
        }

        public int CustomerId { get; }

        public string CustomerName { get; }

        public string Gender { get; }
    }
}
