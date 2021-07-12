using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.TigerCard.Common
{
    [Serializable]
    public class TraceLog : BaseLog
    {
        public string Category { get; set; }
        public override string Type { get; } = "trace";

        public override IEnumerable<KeyValuePair<string, object>> GetLogFields()
        {
            return new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object> ("category", Category)
            };
        }
    }
}
