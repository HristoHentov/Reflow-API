namespace ReflowCore.Exchange
{
    interface IImporter
    {
        void Import(string json);
        object ParseJson(string json);
    }
}
