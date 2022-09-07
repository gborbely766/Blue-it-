using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blue_it.Data
{
    public class Comment
    {
        [Key]       
        public int Id { get; set; }
        [ForeignKey("Answers")]
        public int AnswerId { get; set; }
        [Required]
        public string? Message { get; set; }
        public DateTime SubmissionTime { get; set; } = DateTime.Now;
        public int EditedCount { get; set; } = 0;

    }
}
