
using ReflowModels.EntityModels;

namespace Reflow.Data
{
    using System.Data.Entity;

    public partial class ReflowContext : DbContext
    {
        public ReflowContext()
            : base("name=ReflowContext")
        {
        }

        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Option> Options { get; set; }
        public virtual DbSet<TagEntityModel> Tags { get; set; }
        public virtual DbSet<Filter> Filters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
