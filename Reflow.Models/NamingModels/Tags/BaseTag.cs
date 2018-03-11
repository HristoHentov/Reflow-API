using System;
using System.Collections.Generic;
using ReflowModels.ViewModels;

namespace ReflowModels.NamingModels.Tags
{
    public abstract class BaseTag : ITag
    {

        protected BaseTag(string name)
        {
            this.Name = name;
        }

        public string Name { get; }
        public abstract string ToString(string fileName, IDictionary<string, FileViewModel> files);
    }
}
