using StackUnderdose.Entities;

namespace StackUnderdose.Seeders
{
    public class Seeder
    {
        public static Random rnd = new Random();
        public static void Seed(StackUnderdoseContext dbContext)
        {
            SeedTags.Seed(dbContext);
            SeedUsers.Seed(dbContext);
            SeedQuestions.Seed(dbContext);
            SeedAnswers.Seed(dbContext);
            SeedComments.Seed(dbContext);
        }
    }
}
