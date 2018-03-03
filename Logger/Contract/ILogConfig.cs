using System.Text;

namespace Logger.Contract
{
    public interface ILogConfig
    {
        Level LogLevel { get; }

        Encoding Encoding { get; }

        string TimeFormat { get; }
    }
}
