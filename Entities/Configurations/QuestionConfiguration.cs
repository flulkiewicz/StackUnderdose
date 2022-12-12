using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StackUnderdose.Entities.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> eb)
        {
            eb.Property(x => x.Score)
                  .HasDefaultValue(0);

            eb.Property(x => x.Title)
              .IsRequired();

            eb.Property(x => x.Description)
              .IsRequired();

            eb.Property(x => x.State)
              .HasDefaultValue("Unanswered");

            eb.Property(x => x.CreatedDate)
              .HasDefaultValueSql("getutcdate()");

            eb.Property(x => x.LastUpdatedDate)
              .ValueGeneratedOnUpdate();

            eb.HasOne(q => q.Author)
              .WithMany(u => u.Questions)
              .HasForeignKey(q => q.AuthorId)
              .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
