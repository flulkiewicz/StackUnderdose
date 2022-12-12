using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StackUnderdose.Entities.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> eb)
        {
            eb.Property(x => x.Value)
                  .IsRequired();

            eb.HasMany(t => t.Questions)
              .WithMany(q => q.Tags);
        }
    }
}
