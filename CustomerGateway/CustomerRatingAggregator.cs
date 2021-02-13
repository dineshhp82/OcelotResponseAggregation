using CustomerGateway.Model;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Ocelot.Middleware;
using Ocelot.Multiplexer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CustomerGateway
{
    public class CustomerRatingAggregator : IDefinedAggregator
    {
        public async Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
        {
            var customerResponse = responses[0].Items.DownstreamResponse().Content
                .ReadAsStringAsync();

            var customerInfo = JsonConvert.DeserializeObject<IEnumerable<CustomerInfo>>(customerResponse.Result);

            var customerRatingResponse = responses[1].Items.DownstreamResponse().Content.
                ReadAsStringAsync();

            var customerRating = JsonConvert.DeserializeObject<IEnumerable<CustomerRating>>(customerRatingResponse.Result);

            var aggregatedResponse = customerRating.Select(c =>
            {
                var customer = customerInfo.FirstOrDefault(ci => ci.CustomerId == c.CustomerId);

                var (Id, Name, Gender) = customer == null
                ? (Id: -1, Name: "NA", Gender: "NA")
                : (Id: customer.CustomerId, Name: customer.CustomerName, customer.Gender);

                return new
                {
                    Id,
                    Name,
                    Gender,
                    c.CustomerRate,
                    c.Description
                };
            });

            return await Task.FromResult(new DownstreamResponse(
                new StringContent(
                JsonConvert.SerializeObject(aggregatedResponse, Formatting.Indented)),
                System.Net.HttpStatusCode.OK,
                new List<Header>(), "Ok"));
        }
    }
}
