﻿namespace HackerService.DAL.Models
{
    public class PollPart : Item
    {
        public int Parent { get; set; }
        public int Score { get; set; }
        public string Text { get; set; }
    }
}