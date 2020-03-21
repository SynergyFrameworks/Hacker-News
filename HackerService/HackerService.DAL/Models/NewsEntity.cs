using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HackerService.DAL.Models
{
    public class NewsEntity
    {
        [Column("id")]
        public string id { get; set; }

       
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 20 characters.")]
        public string by { get; set; }
        public int score { get; set; }
        public string title { get; set; }
        public int type { get; set; }
        public string text { get; set; }
        public string url { get; set; }
        public DateTime time { get; set; }
      
    }
}
