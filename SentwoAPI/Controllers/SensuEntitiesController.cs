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

        private const string URL = "https://sensuservice.preprod.ncrsaas.com/api/core/v2/namespaces/cso2_development/entities";

        [HttpGet()]
        public ActionResult<object> GetEntities(string entityName)
        {
            RestClient client;
            if (string.IsNullOrEmpty(entityName))
                client = new RestClient(URL);
            else
                client = new RestClient(URL + "/" + entityName);

            string authToken = new SensuAuthenticationController().GetAuthenticationToken();
            client.AddDefaultHeader("Authorization", "Bearer " + authToken);
            var request = new RestRequest("", Method.GET);
            var response = client.Execute(request);

            return response.Content;
        }
    }
}