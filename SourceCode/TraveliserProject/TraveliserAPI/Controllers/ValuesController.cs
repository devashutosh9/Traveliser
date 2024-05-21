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
    }
}
