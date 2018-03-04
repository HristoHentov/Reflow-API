using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using ReflowModels.NamingModels.Tags;

namespace ReflowCore.Exchange
{
    interface IImporter
    {
        ITag ParseTag(string json, IDictionary<string, Type> avaiableTypes);

        IList<ITag> ParseTagCollection(string json, IDictionary<string, Type> avaiableTypes);
    }
}
