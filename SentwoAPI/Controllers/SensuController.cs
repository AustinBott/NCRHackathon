using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SentwoAPI.Models;
using Nest;
using System.Net.Http;

namespace SentwoAPI.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class SensuController : ControllerBase
    {

        private static readonly HttpClient client = new HttpClient();

        public SensuController()
        {
            //TODO do authentication
        }

        [HttpPost]
        public void PostEntrySensu(Entry entry)
        {


        }
    }
}
