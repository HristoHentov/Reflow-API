using ReflowModels.EntityModels;

namespace ReflowModels
{
    class AutoIncrementTagEntityModel : TagEntityModel
    {
        public int StartFrom { get; set; }

        public int SkipBy { get; set; }

        public bool TrailngZero { get; set; }
    }
}
