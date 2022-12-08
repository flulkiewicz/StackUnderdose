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
            var comments = dbContext.Comments.ToList();

            var random = Seeder.rnd;

            if (!comments.Any())
            {
                var genericComments = new List<Comment>();
                for (int i = 0; i < 100; i++)
                {
                    var genericComment = new Comment
                    {
                        Content = $"Generic question comment {i}",
                        Author = users[random.Next(users.Count)],
                        Question = questions[random.Next(questions.Count)],
                        Score = random.Next(-25, 25)
                    };

                    genericComments.Add(genericComment);
                }
                
                for (int i = 0; i < 300; i++)
                {
                    var genericComment = new Comment
                    {
                        Content = $"Generic answer comment {i}",
                        Author = users[random.Next(users.Count)],
                        Answer = answers[random.Next(answers.Count)],
                        Score = random.Next(-25, 25)
                    };

                    genericComments.Add(genericComment);
                }
                
                dbContext.Comments.AddRange(genericComments);

                dbContext.SaveChanges();
            }
        }
    }
}
