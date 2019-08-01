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
    public class SensuAgentController : ControllerBase {
        /*
        [HttpPost()]
        public ActionResult<object> PostSubscription(string subscriptions)
        {
            SensuChecksController sc = new SensuChecksController();
            ActionResult<object> arobj = sc.PostCheck("powershell.exe -ExecutionPolicy unrestricted -Command \"edit-agent -subscriptions \'" + subscriptions + "\'\"",
                new string[] { "update_agent" },
                10000,
                false,
                null,
                "update_subscriptions",
                "cso2_development");

            sc.ExecuteCheck("update_subscriptions");
            sc.DeleteCheck("update_subscriptions");

            return arobj;
        }*/
    }
}