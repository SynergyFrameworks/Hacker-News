using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HackerService.BLL.Models
{
    public class News
    {
        [Column("id")]

        [Required]
        public int id { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string title { get; set; }
        [Required]
        public DAL.Models.NewsType type { get; set; }
        public string text { get; set; }
        public string url { get; set; }
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string by { get; set; }
        public int score { get; set; }
        public DateTime time { get; set; }

    }
}
