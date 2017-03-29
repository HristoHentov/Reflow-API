using ReflowModels;

namespace Reflow.Data.Contracts
{
    public interface IUnitOfWork
    {
        IRepository<Option> Options { get; }

        IRepository<Tag> Tags { get; }

        IRepository<File> Files { get; }

        IRepository<Filter> Filters { get; }

        int SaveChanges();
    }
}
