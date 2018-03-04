using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Logger.Contract;

namespace Logger
{
    public abstract class BaseLog : ILog
    {
        private readonly Level _logLevel;
        private readonly Encoding _encoding;
        private readonly string _timeFormat;

        public Stream OutputStream { get; protected set; }

        protected BaseLog(ILogConfig config)
        {
            this._logLevel = config.LogLevel;
            this._encoding = config.Encoding;
            this._timeFormat = config.TimeFormat;
        }

        protected async Task WriteMessage(string message, Level logLevel)
        {
            if (logLevel >= _logLevel)
            {
                var taggedMessage = this.StampMessage(message, DateTime.Now, logLevel); //TODO: reencode time and level text to match message encoding.
                byte[] payload = _encoding.GetBytes(taggedMessage);

                await OutputStream.WriteAsync(payload, 0, payload.Length);
            }
        }

        public abstract Task Verbose(string text);

        public abstract Task Info(string text);

        public abstract Task Error(string text);

        public abstract Task Critical(string text);

        public abstract Task Fatal(string text);

        private string StampMessage(string message, DateTime time, Level level)
        {
            return $"[{time.ToString(_timeFormat)}] [{level}] - {message}{Environment.NewLine}";
        }
    }
}