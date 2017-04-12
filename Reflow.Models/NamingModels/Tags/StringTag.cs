using System.Collections.Generic;
using ReflowModels.ViewModels;

namespace ReflowModels.NamingModels.Tags
{
    public class StringTag : ITag
    {
        public string Text { get; set; }
        public string ToString(string fileName, IDictionary<string, FileViewModel> files)
        {
            return Text;
        }
    }
}
