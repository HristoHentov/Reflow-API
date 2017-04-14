using System.Collections.Generic;
using ReflowModels.ViewModels;

namespace ReflowCore.Cache
{
    public static class FilesCache
    {
        public static Dictionary<string, FileViewModel> Files { get; set; }
        
        public static string WorkingDirectory { get; set; }
    }
}
