using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerRatingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerRatingController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerRating>>> GetCustomerRating()
        {
            return await Task.FromResult(new CustomerRating[]
            {
                new CustomerRating(1,5,"Excellent"),
                new CustomerRating(2,2,"Average"),
                new CustomerRating(3,5,"Excellent"),
                new CustomerRating(4,1,"Poor"),
                new CustomerRating(5,3,"Good"),
                new CustomerRating(6,3,"Good"),
                new CustomerRating(7,4,"Satisfactory")
            }); ;
        }
    }
}
