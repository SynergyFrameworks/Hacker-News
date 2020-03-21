using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerService.BLL.Models
{
    public class Poll
    {
        //id
        //    integer
        //The item's unique id.
        //    required

        //deleted
        //    boolean
        //true if the item is deleted.
        //    optional

        //    type
        //string
        //    The type of item.One of "job", "story", "comment", "poll", or "pollopt".I
        //    Allowed Values: job, story, comment, poll, pollopt
        //    required

        //by
        //string
        //    The username of the item's author.
        //    optional

        //    time
        //integer
        //    Creation date of the item, in .
        //optional

        //    dead
        //boolean
        //true if the item is dead.
        //    optional

        //    kids
        //array[integer]
        //The ids of the item's comments, in ranked display order.
        //    optional

        //    parts
        //array[integer]
        //A list of related pollopts, in display order.
        //    optional

        //descendants
        //    integer
        //In the case of stories or polls, the total comment count.
        //    optional

        //    score
        //integer
        //    The story's score, or the votes for a pollopt.
        //    optional

        //title
        //string
        //    The title of the story, poll or job.
        //    optional

        //text
        //string
        //    The comment, story or poll text. HTML.
        //    optional
    }
}
