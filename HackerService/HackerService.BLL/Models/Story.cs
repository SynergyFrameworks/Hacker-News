using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerService.BLL.Models
{
    public class Story
    {
        public int id { get; set; }
        //integer
        //    The item's unique id.
        //    required

        public bool? deleted { get; set; }
         //boolean
        //    true if the item is deleted.
        //    optional


        public string type { get; set; }
        //string
        //    The type of item.One of "job", "story", "comment", "poll", or "pollopt".I
        //    Allowed Values: job, story, comment, poll, pollopt
        //    required

        public string by { get; set; }
        //string
        //    The username of the item's author.
        //    optional


        public int? time { get; set; }
        //integer
        //    Creation date of the item, in .
        //    optional

        public bool? dead { get; set; } 
        //boolean
        //    true if the item is dead.
        //    optional


        public int?[] kids { get; set; }
        //array[integer]
        //The ids of the item's comments, in ranked display order.
        //    optional

        public int? descendants { get; set; }
        //integer
        //    In the case of stories or polls, the total comment count.
        //    optional


        public int? score { get; set; }
        //integer
        //    The story's score, or the votes for a pollopt.
        //    optional

        public string title { get; set; }
        //string
        //    The title of the story, poll or job.
        //    optional


        public string url { get; set; }
        //string
        //    The URL of the story.
        //    optional
    }
}
