using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReflowCore.Constants;
using ReflowModels.NamingModels.Tags;

namespace ReflowCore.Exchange
{
    internal class JsonImporter : IImporter
    {
        ///TODO: After testing for performance, split into different methods. 
        ///TODO: This one should only handle the JObject.Parse and be called parse type or something
        public ITag Import(string json)
        {
            var tagType = JObject.Parse(json).First.First.ToString();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var assembly = assemblies
                .First(a => a.FullName.Split(',')[0] == Consts.ModelsAssemblyName);

            Type neededTagType = 
                assembly
                .ExportedTypes
                .FirstOrDefault(t => t.Name == tagType.ToString());

            return (ITag)JsonConvert.DeserializeObject(json, neededTagType);
        }
    }
}
