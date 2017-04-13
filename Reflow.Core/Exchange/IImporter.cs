using ReflowModels.NamingModels.Tags;

namespace ReflowCore.Exchange
{
    interface IImporter
    {
        ITag Import(string json);
    }
}
