using Assignment.TigerCard.Contracts;

namespace Assignment.TigerCard.Common.Logging
{
    public class InMemoryProvider : ILogProvider
    {
        public string Source => "InMemoryProvider";

        public void WriteLog(ILog log, byte[] logData)
        {
            return;
        }
    }
}
