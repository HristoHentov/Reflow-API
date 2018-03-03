using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReflowModels.EntityModels
{
    public class Tag
    {
        public Tag()
        {
            this.Options = new List<Option>(); // List actually gives better performance for up to approx 10-50 items.
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Option> Options { get; set; }
    }
}
