using System;
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

        private int _streamOffset;

        public Stream OutputStream { get; protected set; }

        protected BaseLog(ILogConfig config)
        {
            this._logLevel = config.LogLevel;
            this._encoding = config.Encoding;
            this._timeFormat = config.TimeFormat;
        }

        protected async Task HandleMessage(string message, Level logLevel)
        {
            if (logLevel >= _logLevel)
            {
                var taggedMessage = $"[{DateTime.Now.ToString(_timeFormat)}][{logLevel}] {message}{Environment.NewLine}"; ///Todo: reencode time and level text to match message encoding.
                byte[] payload = _encoding.GetBytes(taggedMessage);

                await OutputStream.WriteAsync(payload, _streamOffset, payload.Length);

                _streamOffset += payload.Length;
            }
        }


        public abstract void Verbose(string text);

        public abstract void Info(string text);

        public abstract void Error(string text);

        public abstract void Critical(string text);

        public abstract void Fatal(string text);
    }
}