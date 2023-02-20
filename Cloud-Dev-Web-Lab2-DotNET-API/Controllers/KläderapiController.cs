using Cloud_Dev_Web_Lab2_DotNET_API.Modules;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Cloud_Dev_Web_Lab2_DotNET_API.Controllers
{
    [ApiController]
    [Route("watch?v=dwaufhewoigt4o")]
    public class KläderapiController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            using(var client = new HttpClient())
            {
                var endpoint = new Uri("");
                var result = client.GetAsync(endpoint).Result;
                var json = result.Content.ReadAsStringAsync().Result; //json result
                return Ok(json);
            }
        }
        [HttpPost]
        public void Post(Clothes Item)
        {
            using(var client = new HttpClient())
            {
                Uri endpoint = new Uri("");
                Clothes newClothes = new Clothes()
                {
                    id = 333,
                    name = "Paourme",
                    type = "Coat"
                };
                var newClothesJson = JsonConvert.SerializeObject(newClothes);


            }
        }
    }
}
