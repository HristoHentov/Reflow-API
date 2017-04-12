using System.Collections.Generic;
using ReflowModels;
using ReflowModels.ViewModels;

namespace ReflowCore.Cache
{
    public static class FilesCache
    {
        public static Dictionary<string, FileViewModel> Files { get; set; }
    }
}
