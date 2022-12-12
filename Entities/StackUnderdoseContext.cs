using Microsoft.EntityFrameworkCore;
using StackUnderdose.Entities.Configurations;

namespace StackUnderdose.Entities
{
    public class StackUnderdoseContext : DbContext
    {
        public StackUnderdoseContext(DbContextOptions<StackUnderdoseContext> options) : base(options) 
        {


        }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }

    }
}
