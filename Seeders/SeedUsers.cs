using StackUnderdose.Entities;

namespace StackUnderdose.Seeders
{
    public class SeedUsers
    {
        public static void Seed(StackUnderdoseContext dbContext)
        {
            var users = dbContext.Users.ToList();

            if (!users.Any())
            {
                var user1 = new User
                {
                    FirstName = "John",
                    LastName = "Kowalsky",
                    DisplayName = "Johnny11",
                    Email = "johhny@norton.com"
                };

                var user2 = new User
                {
                    FirstName = "Damian",
                    LastName = "Torowalsky",
                    DisplayName = "Damian22",
                    Email = "damian32@wp.com"
                };

                var user3 = new User
                {
                    FirstName = "Karen",
                    LastName = "Asmish",
                    DisplayName = "KAreee",
                    Email = "Karen@norton.com"
                };

                var user4 = new User
                {
                    FirstName = "Pajet",
                    LastName = "Answerosky",
                    DisplayName = "Ansker",
                    Email = "ask@ask.com"
                };

                var user5 = new User
                {
                    FirstName = "Rahmed",
                    LastName = "Questionner",
                    DisplayName = "JustAsking",
                    Email = "johhny@norton.com"
                };

                dbContext.Users.AddRange(user1, user2, user3, user4, user5);

                dbContext.SaveChanges();
            }
        }
    }
}
