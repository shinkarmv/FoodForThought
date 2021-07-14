using System;
using System.Collections.Generic;

namespace Assignment.TigerCard.Contracts
{
    public interface ILog
    {
        string Id { get; }
        DateTime TimeStamp { get; }
        IEnumerable<KeyValuePair<string, object>> GetLogFields();
        string Type { get; }
        string Level { get; }
    }
}
