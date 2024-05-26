using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using TraveliserAPI.Models;

namespace TraveliserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

        public ValuesController(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public string GetProduct(int productId)
        {
            try
            {
                string applicationPath = _hostingEnvironment.ContentRootPath;

                List<artists> artists = new List<artists>();

                DataSet dataSet = new DataSet();
                DBContext dBContext = new DBContext();

                using (var conn = dBContext.GetConnection(applicationPath))
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "select * from artists";
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            artists.Add(new artists()
                            {
                                ArtistId = reader.GetInt32(0),
                                Name = reader.GetString(1)
                            });
                            //var name = reader.GetString(0);                        
                        }
                    }
                    conn.Close();
                }

                return JsonConvert.SerializeObject(artists, Formatting.Indented);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpGet]
        [Route("GetAirports")]
        public List<v_airports> GetAirports()
        {
            List<v_airports> artists = new List<v_airports>();
            try
            {
                string applicationPath = _hostingEnvironment.ContentRootPath;                

                DataSet dataSet = new DataSet();
                DBContext dBContext = new DBContext();

                using (var conn = dBContext.GetConnection(applicationPath))
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "select * from v_airports";
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            artists.Add(new v_airports()
                            {
                                IATA = reader.GetString(0),
                                AirportName = reader.GetString(1),
                                CityCode = reader.GetString(3),
                                CityName = reader.GetString(4),
                                Country = reader.GetString(5),
                                CityId = reader.GetInt32(2)
                            });
                            //var name = reader.GetString(0);                        
                        }
                    }
                    conn.Close();
                }                
            }
            catch (Exception ex)
            {
                
            }
            return artists;
        }
    }
}
