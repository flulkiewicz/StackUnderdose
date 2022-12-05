using System.ComponentModel.DataAnnotations;

namespace StackUnderdose.Entities
{
    public class Answer
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public User Author { get; set; }
        public Guid AuthorId { get; set; }
        public Question Question { get; set; }
        public int QuestionId { get; set; }
        public string Score { get; set; } 
    }
}
