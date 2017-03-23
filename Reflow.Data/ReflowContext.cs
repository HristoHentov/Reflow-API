
namespace Reflow.Data
{
    using System.Data.Entity;
    using ReflowModels;

    public partial class ReflowContext : DbContext
    {
        public ReflowContext()
            : base("name=ReflowContext")
        {
        }

        //TODO: Change absolute to relative path for the connection string.
        //TODO: Add the additional <provider> tag to the app.config if necessary.
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Option> Options { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
