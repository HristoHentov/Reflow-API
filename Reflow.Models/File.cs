namespace ReflowModels
{
    public class File
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string OldName { get; set; }
        public string NewName { get; set; }
        public float Size { get; set; }
        public string SizeScale { get; set; }
    }
}
