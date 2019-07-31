using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentwoAPI.Models
{
    public class SensuAuthentication
    {
        public string access_token { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
