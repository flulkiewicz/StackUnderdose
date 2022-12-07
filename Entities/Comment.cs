namespace StackUnderdose.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public User Author { get; set; }
        public Guid AuthorId { get; set; }
        public Question Question { get; set; }
        public int QuestionId { get; set; }
        public Answer Answer { get; set; }
        public int AnswerId { get; set; }
        public int Score { get; set; }
    }
}
