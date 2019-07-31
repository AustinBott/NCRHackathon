using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace SentwoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensuEntitiesController : ControllerBase
    {
        [HttpGet()]
        public ActionResult<object> GetEntities()
        {
            var url = "https://sensuservice.preprod.ncrsaas.com/api/core/v2/namespaces/cso2_development/entities";

            string authToken = new SensuAuthenticationController().GetAuthenticationToken();
            object result = new object();

            var client = new RestClient(url);
            client.AddDefaultHeader("Authorization", "Bearer " + authToken);
            var request = new RestRequest("", Method.GET);
            var response = client.Execute(request);

            return response.Content;
        }
    }
}