using System.Collections.Generic;

namespace ReflowModels
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Option> Options { get; set; }
    }
}
