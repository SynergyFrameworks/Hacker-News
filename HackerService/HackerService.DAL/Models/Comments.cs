using System.Collections.Generic;

namespace HackerService.DAL.Models
{
    public class Comment : Item
    {
        public List<int> Kids { get; set; }
        public int Parent { get; set; }
        public string Text { get; set; }
    }
}
