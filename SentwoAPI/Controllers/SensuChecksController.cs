using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;

namespace SentwoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensuChecksController : ControllerBase
    {
        private const string URL = "https://sensuservice.preprod.ncrsaas.com/api/core/v2/namespaces/cso2_development/checks";

        [HttpGet()]
        public ActionResult<object> GetChecks(string checkName)
        {
            RestClient client;
            if (string.IsNullOrEmpty(checkName))
                client = new RestClient(URL);
            else
                client = new RestClient(URL + "/" + checkName);

            client.Authenticator = new HttpBasicAuthenticator("ql185017", "wM7+T9xWzucsalAP");
       
            var request = new RestRequest("", Method.GET);
            var response = client.Execute(request);

            return response.Content;
        }


        [HttpPost()]
        public ActionResult<object> PostCheck(string command, string subscriptions, int interval, bool publish, string[] handlers, string name, string namespaceStr) {
            var metadata = new {
                name,
                namespaceStr
            };
            var jsonMetadata = JsonConvert.SerializeObject(metadata);

            var check = new {
                command,
                subscriptions,
                interval,
                publish,
                handlers,
                jsonMetadata
            };
            var jsonCheck = JsonConvert.SerializeObject(check);

            RestClient client = new RestClient(URL) {
                Authenticator = new HttpBasicAuthenticator("ql185017", "wM7+T9xWzucsalAP")
            };

            var request = new RestRequest("", Method.POST);
            request.AddJsonBody(jsonCheck);
            var response = client.Execute(request);

            return response.Content;
        }

        [HttpPut()]
        public ActionResult<object> PutCheck(string command, string subscriptions, int interval, bool publish, string[] handlers, string name, string namespaceStr) {
            var metadata = new {
                name,
                namespaceStr
            };

            var check = new {
                command,
                subscriptions,
                interval,
                publish,
                handlers,
                metadata
            };
            var jsonCheck = JsonConvert.SerializeObject(check);

            RestClient client = new RestClient(URL + "/" + name) {
                Authenticator = new HttpBasicAuthenticator("ql185017", "wM7+T9xWzucsalAP")
            };

            var request = new RestRequest("", Method.PUT);
            request.AddJsonBody(jsonCheck);
            var response = client.Execute(request);

            return response.Content;
        }

        [HttpDelete()]
        public ActionResult<object> DeleteCheck(string name) {

            RestClient client = new RestClient(URL + "/" + name) {
                Authenticator = new HttpBasicAuthenticator("ql185017", "wM7+T9xWzucsalAP")
            };

            var request = new RestRequest("", Method.DELETE);
            var response = client.Execute(request);

            return response.Content;
        }

        [HttpPost()]
        public ActionResult<object> ExecuteCheck(string name) {

            RestClient client = new RestClient(URL + "/" + name + "/execute") {
                Authenticator = new HttpBasicAuthenticator("ql185017", "wM7+T9xWzucsalAP")
            };

            var request = new RestRequest("", Method.POST);
            var response = client.Execute(request);

            return response.Content;
        }
    }
}