using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerInfo>>> GetCustomers()
        {
            var customers = new CustomerInfo[]
            {
               new CustomerInfo(1,"Dinesh","Male"),
               new CustomerInfo(2,"Mukesh","Male"),
               new CustomerInfo(3,"Naresh","Male"),
               new CustomerInfo(4,"Sabita","Female"),
               new CustomerInfo(5,"Rajani","Female"),
            };

            return await Task.FromResult(customers);
        }
    }
}
