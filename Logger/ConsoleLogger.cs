using System;
using Logger.Contract;

namespace Logger
{
    public class ConsoleLogger : BaseLog
    {
        private static readonly ConsoleColor _defaultColor = Console.ForegroundColor;

        public ConsoleLogger() : this(new LogConfiguration())
        {
        }

        public ConsoleLogger(ILogConfig config) : base(config)
        {
            base.OutputStream = Console.OpenStandardOutput();
        }

        public override void Verbose(string text)
        {
            this.WriteToConsole(text, ConsoleColor.Gray, Level.Verbose);
        }

        public override void Info(string text)
        {
            this.WriteToConsole(text, ConsoleColor.Green, Level.Verbose);
        }

        public override void Error(string text)
        {
            this.WriteToConsole(text, ConsoleColor.DarkYellow, Level.Verbose);
        }

        public override void Critical(string text)
        {
            this.WriteToConsole(text, ConsoleColor.Red, Level.Verbose);
        }

        public override void Fatal(string text)
        {
            this.WriteToConsole(text, ConsoleColor.Red, Level.Verbose);
        }

        private async void WriteToConsole(string text, ConsoleColor color, Level level)
        {
            Console.ForegroundColor = color;
            await base.HandleMessage(text, level);
            Console.ForegroundColor = _defaultColor;
        }
    }
}
