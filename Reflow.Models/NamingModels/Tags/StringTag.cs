using System.Collections.Generic;
using ReflowModels.ViewModels;

namespace ReflowModels.NamingModels.Tags
{
    public class StringTag : BaseTag
    {
        public StringTag() : base(nameof(StringTag))
        {
        }

        public string Text { get; set; }

        public override string ToString(string fileName, IDictionary<string, FileViewModel> files)
        {
            return Text;
        }
    }
}
