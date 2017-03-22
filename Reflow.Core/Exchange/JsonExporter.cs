using Newtonsoft.Json;

namespace ReflowCore.Exchange
{
    internal class JsonExporter : IExporter
    {
        public string Export(object data)
        {
            return JsonConvert.SerializeObject(data, Formatting.Indented);
        }
    }
}
