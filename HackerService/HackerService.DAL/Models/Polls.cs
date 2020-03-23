using System.Collections.Generic;

namespace HackerService.DAL.Models
{
    public class Poll : Item
    {
        public List<int> Kids { get; set; }
        public List<int> Parts { get; set; }
        public int Score { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
    }
}