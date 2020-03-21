using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerService.BLL.Models
{
    public class Comment
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

        //    parent
        //integer
        //    The item's parent. For comments, either another comment or the relevant story. For pollopts, the relevant poll.
        //    optional

        //    text
        //string
        //    The comment, story or poll text.HTML.
        //    optional
    }
}
