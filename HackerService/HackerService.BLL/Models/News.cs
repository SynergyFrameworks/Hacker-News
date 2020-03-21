using System;

namespace HackerService.BLL.Models
{
    public class News
    {
        public int id { get; set; }
        public string? title { get; set; }
        public NewsType type { get; set; }
        public DateTime time { get; set; }
      
    }
}
