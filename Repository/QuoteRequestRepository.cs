using Contracts;
using Entities.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Repository
{
    public class QuoteRequestRepository : IQuoteRequestRepository
    {
        public async Task<QuoteRequest> Get()
        {
            QuoteRequest? quoteRequest = new QuoteRequest();

            using HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://jayridechallengeapi.azurewebsites.net/api/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = new HttpResponseMessage();
            var responseTask = client.GetAsync("QuoteRequest");
            responseTask.Wait();
            response = responseTask.Result;

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                quoteRequest = JsonConvert.DeserializeObject<QuoteRequest>(result);
            }

            return quoteRequest;
        }

        public IEnumerable<Listing> GetQuotesByNumPassengers(int numPassengers)
        {
            QuoteRequest quotes = this.Get().Result;
            var results = quotes.Listings.Where(c => c.VehicleType.MaxPassengers.Equals(numPassengers))
                .OrderBy(x => x.VehicleType.MaxPassengers * x.PricePerPassenger);

            return results;
        }
    }
}
