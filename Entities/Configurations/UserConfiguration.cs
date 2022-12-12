using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StackUnderdose.Entities.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> eb)
        {
            eb.Property(x => x.FirstName)
                 .IsRequired();

            eb.Property(x => x.LastName)
              .IsRequired();

            eb.Property(x => x.Email)
              .IsRequired();
        }
    }
}
