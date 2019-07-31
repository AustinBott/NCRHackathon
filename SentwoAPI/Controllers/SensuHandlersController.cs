using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace SentwoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensuHandlersController : ControllerBase
    {
        private readonly string url = "https://sensuservice.preprod.ncrsaas.com/api/core/v2/namespaces/cso2_development/handlers";

        [HttpGet()]
        public ActionResult<object> Get()
        {
            string authToken = new SensuAuthenticationController().GetAuthenticationToken();
            var client = new RestClient(url);
            client.AddDefaultHeader("Authorization", "Bearer " + authToken);
            var request = new RestRequest("", Method.GET);
            var response = client.Execute(request);
            return this.Content(response.Content, "application/json");
        }

        [HttpGet("{handlerName}")]
        public ActionResult<object> Get(string handlerName)
        {
            string authToken = new SensuAuthenticationController().GetAuthenticationToken();
            var client = new RestClient(url);
            client.AddDefaultHeader("Authorization", "Bearer " + authToken);
            var request = new RestRequest(handlerName, Method.GET);
            var response = client.Execute(request);
            return this.Content(response.Content, "application/json");
        }


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
        }

    }
}