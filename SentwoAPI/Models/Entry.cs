using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentwoAPI.Models
{
    public class Entry
    {
        /* Which Namespace this metrics belongs to */
        public string Namespace { get; set; }

        /* The unique identifier of the Entity this metrics belongs to */
        public string EntityId { get; set; }

        /* The time of when this datapoint was generated
         * Always call DateTime.Now when initializing this field
         */
        public DateTime Date { get; set; }

        /* The title of the Metrics this Entry represents
         * e.g. printer_status
         */
        public string MetricTitle { get; set; }

        /* The observed value of the Metrics
         * e.g. 256
         */
        public int MetricValue { get; set; }
         
        /* The status of this Metrics */
        public StatusEnum MetricStatus { get; set; }
}
}
