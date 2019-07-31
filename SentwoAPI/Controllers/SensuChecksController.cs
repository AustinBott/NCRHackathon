using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using RestSharp.Authenticators;

namespace SentwoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensuChecksController : ControllerBase
    {
        [HttpGet()]
        public ActionResult<object> GetChecks(string checkName)
        {
            var url = "https://sensuservice.preprod.ncrsaas.com/api/core/v2/namespaces/cso2_development";

            if (string.IsNullOrEmpty(checkName))
            {
                url += "/checks";
            }
            else
            {
                url += "/checks/" + checkName;
            }

            var client = new RestClient(url);
            client.Authenticator = new HttpBasicAuthenticator("ql185017", "wM7+T9xWzucsalAP");
            var request = new RestRequest("", Method.GET);
            var response = client.Execute(request);

            return response.Content;
        }
    }
}