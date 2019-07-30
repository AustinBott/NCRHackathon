﻿using System;
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

        [HttpPost]
        public async Task<ActionResult<Entry>> PostEntry(Entry entry)
        {
            var ndexRespons = _client.IndexDocument((TimeStampedEntry)entry);

            return CreatedAtAction(entry.EntityId + entry.MetricTitle, entry);
        }

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

        [HttpGet("all")]
        public List<TimeStampedEntry> GetAll()
        {
            var searchResponse = _client.Search<TimeStampedEntry>();
            return searchResponse.Documents.ToList();
        }

        [HttpGet("{name_space}/all")]
        public List<TimeStampedEntry> GetNamespace(string name_space)
        {
            var searchResponse = _client.Search<TimeStampedEntry>(s => s
                .Query(q => q.
                    Match(m => m.
                        Field(f => f.Namespace).Query(name_space))
               ));

            return searchResponse.Documents.ToList();
        

        }

    }
}