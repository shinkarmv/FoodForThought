using Assignment.TigerCard.Contracts;

namespace Assignment.TigerCard.Common.Logging
{
    public interface ILogSink
    {
        string LoggingSource { get; }
        void WriteAsync(ILog log, byte[] logData);
    }
}
