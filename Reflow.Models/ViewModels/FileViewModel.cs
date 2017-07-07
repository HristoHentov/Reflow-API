namespace ReflowModels.ViewModels
{
    public class FileViewModel
    {   public int Key { get; set; }     
        public string OriginalName { get; set; }

        public string NewName { get; set; }

        public string Type { get; set; }

        public string Size { get; set; }

        public bool Filtered { get; set; }
    }
}
