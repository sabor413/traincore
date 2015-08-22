using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;
namespace Training.Utilities.BaseCore.Analytics
{
    [Table(Name = "Conversions")]
    public class Conversions
    {
        [Column]
        public Guid ItemId { get; set; }
        [Column]
        public string GoalName { get; set; }
        [Column]
        public string Value { get; set; }
        [Column]
        public string Data { get; set; }
        [Column]
        public Guid PageEventDefinitionId { get; set; }
        [Column]
        public DateTime DateTime { get; set; }
    }
}
