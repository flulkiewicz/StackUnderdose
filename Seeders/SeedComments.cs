using StackUnderdose.Entities;

namespace StackUnderdose.Seeders
{
    public class SeedComments
    {
        public static void Seed(StackUnderdoseContext dbContext)
        {
            var questions = dbContext.Questions.ToList();
            var users = dbContext.Users.ToList();
            var answers = dbContext.Answers.ToList();

            var random = Seeder.rnd;

            if (!answers.Any())
            {
                var genericAnswers = new List<Answer>();
                for (int i = 0; i < 100; i++)
                {
                    var genericAnswer = new Answer
                    {
                        Content = $"Generic content {i}",
                        Author = users[random.Next(users.Count)],
                        Question = questions[random.Next(questions.Count)],
                        Score = random.Next(-250, 250)
                    };

                    genericAnswers.Add(genericAnswer);
                }

                dbContext.Answers.AddRange(genericAnswers);

                dbContext.SaveChanges();
            }
        }
    }
}
