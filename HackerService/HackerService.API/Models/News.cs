using System;
using System.ComponentModel.DataAnnotations;

namespace HackerService.API.Models
{
    /// <summary>
    /// News type
    /// </summary>
    public class News
    {
        /// <summary>
        /// News id
        /// </summary>
       [Required]
        public int id { get; set; }
        /// <summary>
        /// News title
        /// </summary>
        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string title { get; set; }
        /// <summary>
        /// News type
        /// </summary>
        [Required]
        public NewsType type { get; set; }
        /// <summary>
        /// time
        /// </summary>
        public DateTime time { get; set; }
    
    }
}
