using System.ComponentModel.DataAnnotations;

namespace ReflowModels.EntityModels
{
    public class Option
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        public long? TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}