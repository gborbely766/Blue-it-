using System.ComponentModel.DataAnnotations;

namespace Blue_it.Data
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Message { get; set; }
        public int ViewNumber { get; set; } = 0;
        public int VoteNumber { get; set; } = 0;
        public DateTime SubmissionTime { get; set; } = DateTime.Now;
        public string? Image { get; set; }
    }
}
