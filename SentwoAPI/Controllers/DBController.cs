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
        private readonly ElasticClient _client;

        public DBController()
        {
            var settings = new ConnectionSettings(new Uri("https://a2a41db7756c4027892e36a0b3956249.us-central1.gcp.cloud.es.io:9243"))
                .DefaultIndex("test")
                .BasicAuthentication("elastic", "aeBzBFRF2Ll8HtgAtIa5N5Cz");
            _client = new ElasticClient(settings);
        }

        [HttpGet("test")]
        public String Test()
        {
            return "WORKING";
        }

        //TODO: FIX RETURN STATEMENT
        //TODO: ALSO POST TO SENSU BACKEND
        [HttpPost]
        public async Task<ActionResult<Entry>> PostEntry(Entry entry)
        {
            var ndexRespons = _client.IndexDocument((TimeStampedEntry)entry);
            return null;
            //return CreatedAtAction(entry.EntityId + entry.MetricTitle, entry);
        }

        //TODO: ADD SEPERATE PUT REQUEST THAT JUST PUSHS TO THIS API

        /*
         * Get Method that allows you to get an Entity By:
         * Name Space, entityId, metricTitle
         * Returns: Most Recent Entity that matches above criteria
         */
        [HttpGet("{name_space}/{entityId}/{metricTitle}")]
        public async Task<ActionResult<TimeStampedEntry>> GetLastEntry(string name_space, string entityId, string metricTitle)
        {
            var searchResponse = _client.Search<TimeStampedEntry>(s => s
                .Size(1)
                .Sort(ss => ss
                    .Descending(p => p.Date))
                .Query(q => q.
                    Match(m => m.
                        Field(f => f.Namespace).Query(name_space)) && q
                    .Match(m => m.
                        Field(f => f.EntityId).Query(entityId)) && q
                    .Match(m => m.
                        Field(f => f.MetricTitle).Query(metricTitle)))
               );

            return searchResponse.Hits.Single().Source;
        }

        /*
         *Get method to return ALL Entries
         * Returns: Sorted List with Most Recent Entity First
         */
        [HttpGet("all")]
        public List<TimeStampedEntry> GetAll()
        {
            var searchResponse = _client.Search<TimeStampedEntry>(s => s
            .Sort(ss => ss
            .Descending(p => p.Date))
            );
            return searchResponse.Documents.ToList();
        }

        /*
         * Get Method to returns all entries in a given namespace
         * Returns: Sorted List with Most recent Entity first
         */
        [HttpGet("{name_space}/all")]
        public List<TimeStampedEntry> GetNamespace(string name_space)
        {
            var searchResponse = _client.Search<TimeStampedEntry>(s => s
            .Sort(ss => ss
                .Descending(p => p.Date))
                .Query(q => q.
                    Match(m => m.
                        Field(f => f.Namespace).Query(name_space))
               ));

            return searchResponse.Documents.ToList();
        }

        /*
         * Get Method to Return Entity by ID within a namespace
         * Returns: most recent entity that matches ID
         *
         */
        [HttpGet("{name_space}/{entityId}")]
        public List<TimeStampedEntry> GetByID(string name_space, string EntityId)
        {
            var searchResponse = _client.Search<TimeStampedEntry>(s => s
            .Size(1)
            .Sort(ss => ss
                .Descending(p => p.Date))
            .Query(q => q
                .Bool(b => b
                    .Must(mu => mu
                        .Match(m => m
                            .Field(f => f.Namespace)
                            .Query(name_space)
                ), mu => mu
                .Match(m => m
                    .Field(f => f.EntityId)
                    .Query(EntityId)
                )
            )
        )
    )
);
            return searchResponse.Documents.ToList();
        }

    }
}