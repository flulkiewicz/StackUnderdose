using StackUnderdose.Entities;

namespace StackUnderdose.Seeders
{
    public class SeedQuestions
    {
        public static void Seed(StackUnderdoseContext dbContext)
        {
            var questions = dbContext.Questions.ToList();
            var users = dbContext.Users.ToList();

            var random = Seeder.rnd;

            if (!questions.Any())
            {
                var genericQuestions = new List<Question>();
                for (int i = 0; i < 30; i++)
                {
                    var genericQuestion = new Question
                    {
                        Title = $"Generic Question {i}",
                        Description = $"Generic Description {i}",
                        Author = users[random.Next(users.Count)],
                        Score = random.Next(100)
                    };

                    genericQuestions.Add(genericQuestion);
                }

                dbContext.Questions.AddRange(genericQuestions);

                dbContext.SaveChanges();
            }
        }



    }
}
