using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Traveliser.Models
{
    public class TraveliserService
    {
        public string url = "http://localhost:5167";
        public async Task<List<AirportVM>> GetAirportData()
        {
            List<AirportVM> airports = new List<AirportVM>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/values/getairports");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    airports = JsonConvert.DeserializeObject<List<AirportVM>>(data) ?? airports;
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }

            return airports;
        }
    }
}
