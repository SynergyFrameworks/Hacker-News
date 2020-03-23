using System;
using System.ComponentModel.DataAnnotations;

namespace HackerService.API.Models
{
    /// <summary>
    /// News type
    /// </summary>
    public class News
    {

       [Required]
        public int id { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string title { get; set; }
        [Required]
        public NewsType type { get; set; }
        public string text { get; set; }
        public string url { get; set; }
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string by { get; set; }
        public int score { get; set; }
        public DateTime time { get; set; }

    }
}
