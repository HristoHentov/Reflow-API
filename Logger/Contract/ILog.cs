namespace Logger.Contract
{
    public interface ILog
    {
        void Verbose(string text);

        void Info(string text);

        void Error(string text);

        void Critical(string text);

        void Fatal(string text);
    }
}
