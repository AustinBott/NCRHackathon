using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using SentwoAPI.Models;

namespace SentwoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensuAuthenticationController : ControllerBase
    {
        [HttpGet()]
        public ActionResult<string> Get()
        {
            var client = new RestClient("https://sensuservice.preprod.ncrsaas.com/auth");
            client.Authenticator = new HttpBasicAuthenticator("ql185017", "wM7+T9xWzucsalAP");
            var request = new RestRequest("", Method.GET);
            var response = client.Execute(request);

            return this.Content(response.Content, "application/json");
        }

        public string GetAuthenticationToken()
        {
            var client = new RestClient("https://sensuservice.preprod.ncrsaas.com/auth");
            client.Authenticator = new HttpBasicAuthenticator("ql185017", "wM7+T9xWzucsalAP");
            var request = new RestRequest("", Method.GET);
            var response = client.Execute(request);

            var conversion = JsonConvert.DeserializeObject<SensuAuthentication>(response.Content.ToString());

            return conversion.access_token;
        }
    }
}