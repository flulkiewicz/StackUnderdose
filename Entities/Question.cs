namespace StackUnderdose.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string AuthorId { get; set; }
        public int Score { get; set; }
        public string State { get; set; }
    }
}
