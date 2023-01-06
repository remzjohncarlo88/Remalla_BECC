using Contracts;
using Entities.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class LocationRepository : ILocationRepository
    {
        private string key = "f087e9b84cf1f0c17f9921f83a8f4857";
        public string GetCity(string IPAddress)
        {            
            string? city = string.Empty;
            using HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://api.ipstack.com/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = new HttpResponseMessage();
            var responseTask = client.GetAsync(IPAddress + "?access_key=" + key);
            responseTask.Wait();
            response = responseTask.Result;

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                city = JsonConvert.DeserializeObject<Location>(result).City;
            }

            return city;
        }
    }
}
