using System.ComponentModel.DataAnnotations;

namespace Blue_it.Data
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        public int ViewNumber { get; set; }
        public int VoteNumber { get; set; }
        public DateTime SubmissionTime { get; set; } = DateTime.Now;
        public string? Image { get; set; }
    }
}
