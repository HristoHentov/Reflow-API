using Reflow.Data.Contracts;
using ReflowModels.EntityModels;

namespace Reflow.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ReflowContext context;
        private IRepository<Tag> tags;
        private IRepository<Option> options;
        private IRepository<File> files;
        private IRepository<Filter> filters;

        public UnitOfWork()
        {
            this.context = Data.Context;
        }

        public IRepository<Option> Options
            => this.options ?? (this.options = new Repository<Option>(this.context.Options));
        public IRepository<Tag> Tags
            => this.tags ?? (this.tags = new Repository<Tag>(this.context.Tags));
        public IRepository<File> Files
            => this.files ?? (this.files = new Repository<File>(this.context.Files));
        public IRepository<Filter> Filters
            => this.filters ?? (this.filters = new Repository<Filter>(this.context.Filters));

        public int SaveChanges()
        {
            return context.SaveChanges();
        }
    }
}
