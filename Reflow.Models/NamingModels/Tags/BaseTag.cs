using System;
using System.Collections.Generic;
using ReflowModels.ViewModels;

namespace ReflowModels.NamingModels.Tags
{
    public abstract class BaseTag : ITag, IEquatable<BaseTag>
    {
        private static int _internalId = 0;

        protected BaseTag(string name)
        {
            this.Id = _internalId++;
            this.Name = name;
        }

        public int Id { get; }
        public string Name { get; }
        public abstract string ToString(string fileName, IDictionary<string, FileViewModel> files);

        public bool Equals(BaseTag other)
        {
            return other != null && this.Id == other.Id;
        }
    }
}
