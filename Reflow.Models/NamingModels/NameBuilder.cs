using System;
using System.Collections.Generic;
using ReflowModels.NamingModels.Tags;
using ReflowModels.ViewModels;

namespace ReflowModels.Naming
{
    public class NameBuilder
    {
        public NameBuilder()
        {
            this.Tags = new List<ITag>();
        }
        public ICollection<ITag> Tags { get; set; }

        public IDictionary<string, string> Resolve(IDictionary<string, FileViewModel> files)
        {
            IDictionary<string, string> newNames = new Dictionary<string, string>(); ///TODO: Dependency Injection
            foreach (var file in files)
            {
                string newName = string.Empty;
                foreach (var tag in Tags)
                  newName += (tag.ToString(file.Key, files));

                newNames.Add(file.Key, newName);
            }
            return newNames;
        }
    }
}
