using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReflowModels
{
    public class File
    {
        public long Id { get; set; }
        public string Type { get; set; }
        [Required]
        public string OldName { get; set; }
        [Required]
        public string NewName { get; set; }
        [Required]
        public string Path { get; set; }
        [Column(TypeName = "real")]
        public double? Size { get; set; }
        public string SizeScale { get; set; }
    }
}
