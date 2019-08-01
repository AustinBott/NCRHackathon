using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace SentwoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensuHandlersController : ControllerBase
    {
        private const string URL = "https://sensuservice.preprod.ncrsaas.com/api/core/v2/namespaces/cso2_development/handlers";

        [HttpGet()]
        public ActionResult<object> Get()
        {
            string authToken = new SensuAuthenticationController().GetAuthenticationToken();
            var client = new RestClient(URL);
            client.AddDefaultHeader("Authorization", "Bearer " + authToken);
            var request = new RestRequest("", Method.GET);
            var response = client.Execute(request);
            return this.Content(response.Content, "application/json");
        }

        [HttpGet("{handlerName}")]
        public ActionResult<object> Get(string handlerName)
        {
            string authToken = new SensuAuthenticationController().GetAuthenticationToken();
            var client = new RestClient(URL);
            client.AddDefaultHeader("Authorization", "Bearer " + authToken);
            var request = new RestRequest(handlerName, Method.GET);
            var response = client.Execute(request);
            return this.Content(response.Content, "application/json");
        }

        /*
        [HttpPost()]
        public ActionResult<object> Post(Models.SensuHandler handler)
        {
            string authToken = new SensuAuthenticationController().GetAuthenticationToken();
            var client = new RestClient(url);
            client.AddDefaultHeader("Authorization", "Bearer " + authToken);
            var test = handler;
            var request = new RestRequest("", Method.GET);
            var response = client.Execute(request);
            return this.Content(response.Content, "application/json");
        }*/

        [HttpPost()]
        public ActionResult<object> PostHandler([FromBody]object handler) {

            var strHandler = JsonConvert.SerializeObject(handler);

            RestClient client = new RestClient(URL);

            string authToken = new SensuAuthenticationController().GetAuthenticationToken();
            client.AddDefaultHeader("Authorization", "Bearer " + authToken);

            var request = new RestRequest("", Method.POST);
            request.AddJsonBody(strHandler);
            var response = client.Execute(request);

            return response.Content;
        }

        [HttpPut()]
        public ActionResult<object> PutHandler([FromBody]object handler) {

            var jsonHandler = JsonConvert.SerializeObject(handler);
            JObject jsonObj = JObject.Parse(jsonHandler);
            JToken jtok = jsonObj.SelectToken("metadata.name");

            var nameStr = jtok.ToString();

            RestClient client = new RestClient(URL + "/" + nameStr);

            string authToken = new SensuAuthenticationController().GetAuthenticationToken();
            client.AddDefaultHeader("Authorization", "Bearer " + authToken);

            var request = new RestRequest("", Method.PUT);
            request.AddJsonBody(jsonHandler);
            var response = client.Execute(request);

            return response.Content;
        }

        [HttpDelete()]
        public ActionResult<object> DeleteHandler([FromBody] string name) {

            RestClient client = new RestClient(URL + "/" + name);

            string authToken = new SensuAuthenticationController().GetAuthenticationToken();
            client.AddDefaultHeader("Authorization", "Bearer " + authToken);

            var request = new RestRequest("", Method.DELETE);
            var response = client.Execute(request);

            return response.Content;
        }

    }
}