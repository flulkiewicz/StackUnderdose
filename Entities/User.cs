namespace StackUnderdose.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }

        public string Email { get; set; }
        public List<Answer> Answers { get; set; } = new List<Answer>();
        public List<Question> Questions { get; set; } = new List<Question>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
