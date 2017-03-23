using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReflowModels
{
    public class Tag
    {
        public Tag()
        {
            this.Options = new HashSet<Option>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Option> Options { get; set; }
    }
}
