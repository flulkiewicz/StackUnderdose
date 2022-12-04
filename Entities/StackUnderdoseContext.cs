using Microsoft.EntityFrameworkCore;

namespace StackUnderdose.Entities
{
    public class StackUnderdoseContext : DbContext
    {
        public StackUnderdoseContext(DbContextOptions<StackUnderdoseContext> options) : base(options) { }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }

        
    }
}
