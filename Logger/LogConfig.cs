using System.Text;
using Logger.Contract;

namespace Logger
{
    public class LogConfiguration : ILogConfig
    {
        private readonly Level _defaultLevel = Level.Verbose;
        private readonly Encoding _defaultEncoding= Encoding.UTF8;
        private readonly string _timeFormat = "dd/MM/yyyy - HH:mm";

        public LogConfiguration()
        {
            this.LogLevel = _defaultLevel;
            this.Encoding = _defaultEncoding;
            this.TimeFormat = _timeFormat;
        }

        public LogConfiguration(Level level)
        {
            this.LogLevel = level;
            this.Encoding = _defaultEncoding;
            this.TimeFormat = _timeFormat;
        }

        public LogConfiguration(Encoding encoding)
        {
            this.LogLevel = _defaultLevel;
            this.Encoding = encoding;
            this.TimeFormat = _timeFormat;
        }

        public LogConfiguration(string timeFormat)
        {
            this.LogLevel = _defaultLevel;
            this.Encoding = _defaultEncoding;
            this.TimeFormat = timeFormat;
        }

        public LogConfiguration(Level level, Encoding encoding)
        {
            this.LogLevel = level;
            this.Encoding = encoding;
            this.TimeFormat = _timeFormat;
        }

        public LogConfiguration(Level level, Encoding encoding, string timeFormat)
        {
            this.LogLevel = level;
            this.Encoding = encoding;
            this.TimeFormat = timeFormat;
        }

        public Level LogLevel { get; }
        public Encoding Encoding { get; }
        public string TimeFormat { get; }
    }
}
