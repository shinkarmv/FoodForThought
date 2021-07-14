using Assignment.TigerCard.Contracts;

namespace Assignment.TigerCard.Common.Logging
{
    public interface ILogProvider
    {
        string Source { get; }
        void WriteLog(ILog log, byte[] data);
    }
}
