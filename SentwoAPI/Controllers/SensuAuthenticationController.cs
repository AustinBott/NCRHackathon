﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SentwoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensuAuthenticationController : ControllerBase
    {
        [HttpGet()]
        public async Task<ActionResult<object>> GetAuthenticationToken()
        {
            var token = "";
            return token;
        }
    }
}