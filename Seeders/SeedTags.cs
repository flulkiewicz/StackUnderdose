using Microsoft.EntityFrameworkCore;
using StackUnderdose.Entities;

namespace StackUnderdose.Seeders
{
    public class SeedTags
    {
        public static void Seed(StackUnderdoseContext dbContext)
        {
            var tags = dbContext.Tags.ToList();

            if(!tags.Any())
            {
                var tag1 = new Tag { Value = "C#" };

                var tag2 = new Tag { Value = "Programming" };

                var tag3 = new Tag { Value = "lambo" };

                var tag4 = new Tag { Value = "entity" };

                var tag5 = new Tag { Value = "imagination" };

                dbContext.Tags.AddRange(tag1, tag2, tag3, tag4, tag5);

                dbContext.SaveChanges();
            }
        }

    }
}
