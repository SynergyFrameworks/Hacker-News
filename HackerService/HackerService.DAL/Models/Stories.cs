﻿using System.Collections.Generic;


namespace HackerService.DAL.Models
{
    public class Story : Item
    {
        public List<int> Kids { get; set; }
        public int Score { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }
    }
}