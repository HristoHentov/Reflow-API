using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReflowCore.Constants;
using ReflowModels.NamingModels.Tags;

namespace ReflowCore.Exchange
{
    internal class JsonImporter : IImporter
    {
        public ITag ParseTag(string json, IDictionary<string, Type> avaiableTypes)
        {
            var type = JObject.Parse(json)[nameof(ITag.Name)].ToString();
            return (ITag)JsonConvert.DeserializeObject(json, avaiableTypes[type]);

        }

        public IList<ITag> ParseTagCollection(string json, IDictionary<string, Type> avaiableTypes)
        {
            var typesArray = JArray.Parse(json);
            return typesArray
                .Select(t => ParseTagEntry(t, avaiableTypes[t[nameof(ITag.Name)].ToString()]))
                .ToList();
        }


        private ITag ParseTagEntry(JToken token, Type type)
        {
            return (ITag)JsonConvert.DeserializeObject(token.ToString(), type);
        }
    }
}
