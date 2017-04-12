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

        public string Resolve(IDictionary<string, FileViewModel> files)
        {
            foreach (var file in files)
            {
                string newName = string.Empty;
                foreach (var tag in Tags)
                {
                    tag.ToString(file.Key, files);
                }
            }

            return null;
        }
    }
}
