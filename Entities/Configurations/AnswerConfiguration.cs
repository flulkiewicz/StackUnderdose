using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StackUnderdose.Entities.Configurations
{
    public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> eb)
        {
            eb.Property(x => x.Score)
                  .HasDefaultValue(0);

            eb.Property(x => x.CreatedDate)
              .HasDefaultValueSql("getutcdate()");

            eb.Property(x => x.LastUpdatedDate)
              .ValueGeneratedOnUpdate();

            eb.HasOne(a => a.Author)
              .WithMany(u => u.Answers)
              .HasForeignKey(a => a.AuthorId)
              .OnDelete(DeleteBehavior.NoAction);

            eb.HasOne(a => a.Question)
              .WithMany(q => q.Answers)
              .HasForeignKey(a => a.QuestionId);
        }
    }
}
