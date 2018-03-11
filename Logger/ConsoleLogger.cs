using System;
using System.Text;
using System.Threading.Tasks;
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

        public override async Task Verbose(string text)
        {
            await this.WriteToConsole(text, ConsoleColor.Gray, Level.Verbose);
        }

        public override async Task Info(string text)
        {
            await this.WriteToConsole(text, ConsoleColor.Green, Level.Info);
        }

        public override async Task Error(string text)
        {
            await this.WriteToConsole(text, ConsoleColor.DarkYellow, Level.Error);
        }

        public override async Task Critical(string text)
        {
            await this.WriteToConsole(text, ConsoleColor.Red, Level.Critical);
        }

        public override async Task Fatal(string text)
        {
            await this.WriteToConsole(text, ConsoleColor.Red, Level.Fatal);
        }

        private async Task WriteToConsole(string text, ConsoleColor color, Level level)
        {
            Console.ForegroundColor = color;
            await base.WriteMessage(text, level);
            Console.ForegroundColor = _defaultColor;
        }
    }
}
