using Microsoft.EntityFrameworkCore;

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
            modelBuilder.Entity<Answer>(eb =>
            {
                eb.Property(x => x.Score)
                  .HasDefaultValue(0);

                eb.HasOne(a => a.Author)
                  .WithMany(u => u.Answers)
                  .HasForeignKey(a => a.AuthorId)
                  .OnDelete(DeleteBehavior.NoAction);

                eb.HasOne(a => a.Question)
                  .WithMany(q => q.Answers)
                  .HasForeignKey(a => a.QuestionId);
            });

            modelBuilder.Entity<Question>(eb => 
            {
                eb.Property(x => x.Score)
                  .HasDefaultValue(0);

                eb.Property(x => x.Title)
                  .IsRequired();

                eb.Property(x => x.Description)
                  .IsRequired();

                eb.Property(x => x.State)
                  .HasDefaultValue("Unanswered");

                eb.HasOne(q => q.Author)
                  .WithMany(u => u.Questions)
                  .HasForeignKey(q => q.AuthorId)
                  .OnDelete(DeleteBehavior.NoAction);
            });

                

            modelBuilder.Entity<Tag>(eb =>
            {
                eb.Property(x => x.Value)
                  .IsRequired();

                eb.HasMany(t => t.Questions)
                  .WithMany(q => q.Tags);
            });

            modelBuilder.Entity<User>(eb =>
            {
                eb.Property(x => x.FirstName)
                  .IsRequired();

                eb.Property(x => x.LastName)
                  .IsRequired();

                eb.Property(x => x.Email)
                  .IsRequired();
            });

            modelBuilder.Entity<Comment>(eb =>
            {
                eb.HasOne(c => c.Author)
                  .WithMany(a => a.Comments)
                  .HasForeignKey(c => c.AuthorId)
                  .OnDelete(DeleteBehavior.NoAction);

                eb.HasOne(c => c.Question)
                  .WithMany(q => q.Comments)
                  .HasForeignKey(c => c.QuestionId)
                  .OnDelete(DeleteBehavior.NoAction);

                eb.HasOne(c => c.Answer)
                  .WithMany(a => a.Comments)
                  .HasForeignKey(c => c.AnswerId)
                  .OnDelete(DeleteBehavior.NoAction);
  
            });
        }

    }
}
