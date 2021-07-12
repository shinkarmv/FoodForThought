using System;
using System.Collections.Generic;

namespace Assignment.TigerCard.Contracts
{
    public interface ILog
    {
        string Id { get; }
        DateTime LogTime { get; }
        IEnumerable<KeyValuePair<string, object>> GetFields();
        string Type { get; }
        string Level { get; }
    }
}
