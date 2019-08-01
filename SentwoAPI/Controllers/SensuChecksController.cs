using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SentwoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensuChecksController : ControllerBase
    {
        private const string URL = "https://sensuservice.preprod.ncrsaas.com/api/core/v2/namespaces/cso2_development/checks";

        [HttpGet()]
        public ActionResult<object> GetChecks() {
            string authToken = new SensuAuthenticationController().GetAuthenticationToken();
            RestClient client = new RestClient(URL);

            client.AddDefaultHeader("Authorization", "Bearer " + authToken);

            var request = new RestRequest("", Method.GET);
            var response = client.Execute(request);

            return response.Content;
        }

        [HttpGet("{checkName}")]
        public ActionResult<object> GetChecks(string checkName)
        {
            string authToken = new SensuAuthenticationController().GetAuthenticationToken();
            RestClient client = new RestClient(URL + "/" + checkName);

            client.AddDefaultHeader("Authorization", "Bearer " + authToken);

            var request = new RestRequest("", Method.GET);
            var response = client.Execute(request);

            return response.Content;
        }

        [HttpPost()]
        public ActionResult<object> PostCheck([FromBody]object check) {

            var strCheck = JsonConvert.SerializeObject(check);

            RestClient client = new RestClient(URL);

            string authToken = new SensuAuthenticationController().GetAuthenticationToken();
            client.AddDefaultHeader("Authorization", "Bearer " + authToken);

            var request = new RestRequest("", Method.POST);
            request.AddJsonBody(strCheck);
            var response = client.Execute(request);

            return response.Content;
        }

        [HttpPut()]
        public ActionResult<object> PutCheck([FromBody]object check) {
            
            var jsonCheck = JsonConvert.SerializeObject(check);
            JObject jsonObj = JObject.Parse(jsonCheck);
            JToken jtok = jsonObj.SelectToken("metadata.name");

            var nameStr = jtok.ToString();

            RestClient client = new RestClient(URL + "/" + nameStr);

            string authToken = new SensuAuthenticationController().GetAuthenticationToken();
            client.AddDefaultHeader("Authorization", "Bearer " + authToken);

            var request = new RestRequest("", Method.PUT);
            request.AddJsonBody(jsonCheck);
            var response = client.Execute(request);

            return response.Content;
        }

        [HttpDelete("{name}")]
        public ActionResult<object> DeleteCheck(string name) {

            RestClient client = new RestClient(URL + "/" + name);

            string authToken = new SensuAuthenticationController().GetAuthenticationToken();
            client.AddDefaultHeader("Authorization", "Bearer " + authToken);

            var request = new RestRequest("", Method.DELETE);
            var response = client.Execute(request);

            return response.Content;
        }

        
        [HttpPost("Execute")]
        public ActionResult<object> ExecuteCheck([FromBody] string name) {

            RestClient client = new RestClient(URL + "/" + name + "/execute");

            string authToken = new SensuAuthenticationController().GetAuthenticationToken();
            client.AddDefaultHeader("Authorization", "Bearer " + authToken);

            var request = new RestRequest("", Method.POST);
            var response = client.Execute(request);

            return response.Content;
        }
    }
}