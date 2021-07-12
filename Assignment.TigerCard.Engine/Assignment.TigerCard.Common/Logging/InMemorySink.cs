using Assignment.TigerCard.Contracts;

namespace Assignment.TigerCard.Common.Logging
{
    public class InMemorySink : ILogSink
    {
        public string LoggingSource => "inmemorysink";

        public void WriteAsync(ILog log, byte[] logData)
        {
            return;
        }
    }
}
