using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SentwoAPI.Models;
using Nest;

namespace SentwoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DBController : ControllerBase
    {
        private readonly EntryContext _context;
        private readonly ElasticClient _client;

        public DBController(EntryContext context)
        {
            //_context = context;

            //if (_context.EntryContexts.Count() == 0)
            //{
            //    /* Create a new Entry if collection is empty,
            //     * which means you can't delete all Entries.
            //     * 
            //     * [TODO] Get rid of this logic
            //     *        Here to provide example.
            //     */
            //    _context.EntryContexts.Add(
            //        new Entry
            //        {
            //            Namespace = "demo_jj185175",
            //            EntityId = "CSO_Marche_22-7",
            //            Date = DateTime.Now,
            //            MetricTitle = "printer_status",
            //            MetricValue = 256,
            //            MetricStatus = StatusEnum.Warning
            //        });
            //    _context.SaveChanges();
            //}
            var settings = new ConnectionSettings(new Uri("https://a2a41db7756c4027892e36a0b3956249.us-central1.gcp.cloud.es.io:9243"))
                .DefaultIndex("test")
                .BasicAuthentication("elastic", "aeBzBFRF2Ll8HtgAtIa5N5Cz");
            _client = new ElasticClient(settings);
        }

        [HttpPost]
        public async Task<ActionResult<Entry>> PostEntry(Entry entry)
        {
            var ndexRespons = _client.IndexDocument(entry);

            /* Swap below 2 lines out for actual adding to ElasticSearch */
            //_context.EntryContexts.Add(entry);
            //await _context.SaveChangesAsync();

            return CreatedAtAction(entry.EntityId + entry.MetricTitle, entry);
        }

        //[HttpGet("{name_space}/{entityId}/{metricTitle}")]
        //public async Task<ActionResult<TodoItem>> GetLastEntry(string name_space, string entityId, string metricTitle)
        //{
        //    // [TODO]
        //    return;
        //}

    }
}