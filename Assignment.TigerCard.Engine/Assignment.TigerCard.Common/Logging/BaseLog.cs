using Assignment.TigerCard.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.TigerCard.Common
{
    public abstract class BaseLog : ILog
    {
        protected BaseLog()
        {
            Id = Guid.NewGuid().ToString();
            TimeStamp = DateTime.UtcNow;
        }

        public string Id { get; set; }

        public DateTime TimeStamp { get; set; }

        public abstract string Type { get; }

        public string Level { get; set; }

        public virtual IEnumerable<KeyValuePair<string, object>> GetLogFields()
        {
            var map = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
            {
                { "id", Id },
                { "log_time", TimeStamp },
            };
            var fields = GetLogFields();
            fields?.ForEach(f => map[f.Key] = f.Value);

            // Add attributes
            foreach (var key in _attributes.Keys)
            {
                if (map.ContainsKey(key) == true && map[key] != null)
                    map["attr_" + key] = _attributes[key];
                else
                    map[key] = _attributes[key];
            }
            return map.ToList();
        }

        private readonly IDictionary<string, object> _attributes = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        protected abstract List<KeyValuePair<string, object>> GetLogFields();
    }
}
