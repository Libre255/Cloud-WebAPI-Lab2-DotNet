using Cloud_Dev_Web_Lab2_DotNET_API.Modules;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Cloud_Dev_Web_Lab2_DotNET_API.Controllers
{
    [ApiController]
    [Route("KladerAPIDotNet")]
    public class KläderapiController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            using(var client = new HttpClient())
            {
                var endpoint = new Uri("https://clothesapi.azurewebsites.net/getClothes");
                var result = client.GetAsync(endpoint).Result;
                var json = result.Content.ReadAsStringAsync().Result; 
                return Ok(json);
            }
        }
        [HttpPost]
        public IActionResult Post(Clothes Item)
        {
            using(var client = new HttpClient())
            {
                Uri endpoint = new Uri("https://clothesapi.azurewebsites.net/addclothes");
                var newClothesJson = JsonConvert.SerializeObject(Item);
                var payload = new StringContent(newClothesJson, Encoding.UTF8, "application/json");
                var result = client.PostAsync(endpoint, payload).Result.Content.ReadAsStringAsync().Result;

                return Ok(result);
            }
        }
        [HttpDelete]
        public IActionResult Delet(int Id)
        {
            using (var client = new HttpClient())
            {
                Uri endpoint = new Uri("https://clothesapi.azurewebsites.net/deletclothes", UriKind.Relative);
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = endpoint,
                    Content = JsonContent.Create(Id)
                };
                Task<HttpResponseMessage> response = client.SendAsync(request);//may not work
                var finalResult = response.Result.RequestMessage.ToString();
                return Ok(response);
            }
        }
    }
}
