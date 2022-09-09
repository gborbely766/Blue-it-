using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blue_it.Data
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Message { get; set; }
        public int VoteNumber { get; set; } = 0;
        public int QuestionId { get; set; }
        public DateTime SubmissionTime { get; set; } = DateTime.Now;
        public string? Image { get; set; }
    }
}
