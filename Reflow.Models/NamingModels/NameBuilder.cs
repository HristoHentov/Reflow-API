using System;
using System.Collections.Generic;
using ReflowModels.NamingModels.Tags;
using ReflowModels.ViewModels;

namespace ReflowModels.Naming
{
    public sealed class NameBuilder
    {
        private static readonly Lazy<NameBuilder> _singletonInstance = new Lazy<NameBuilder>(() => new NameBuilder());

        public static NameBuilder  Instance => _singletonInstance.Value;


        private NameBuilder()
        {
            Tags = new List<ITag>();
        }

        public IList<ITag> Tags { get; set; }

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
