namespace StackUnderdose.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public User Author { get; set; }
        public Guid AuthorId { get; set; }
        public int Score { get; set; }
        public string State { get; set; }
        public List<Answer> Answers { get; set; } = new List<Answer>();
        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}
