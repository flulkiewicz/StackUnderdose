using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StackUnderdose.Entities.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> eb)
        {
            eb.Property(x => x.CreatedDate)
                  .HasDefaultValueSql("getutcdate()");

            eb.Property(x => x.LastUpdatedDate)
              .ValueGeneratedOnUpdate();

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

            eb.HasOne(c => c.ParentComment)
              .WithMany()
              .HasForeignKey(c => c.ParentCommentId);
        }
    }
}
