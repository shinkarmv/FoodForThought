using System;
using System.Collections.Generic;

namespace Assignment.TigerCard.Common
{
    [Serializable]
    public class ExceptionLog : BaseLog
    {
        public override string Type { get; } = "exception";
        public string ExceptionType { get; set; }
        public string StackTrace { get; set; }
        public string InnerException { get; set; }

        protected override List<KeyValuePair<string, object>> GetLogFields()
        {
            return new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object> ("ex_type", ExceptionType),
                new KeyValuePair<string, object> ("stack_trace", StackTrace),
                new KeyValuePair<string, object> ("inner_exception", InnerException)
            };
        }
    }
}
