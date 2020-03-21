using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerService.BLL.Models
{
    public class User
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }


        //id
        //string
        //    The user's unique username. Case-sensitive.
        //    required

        //    delay
        //integer
        //    Delay in minutes between a comment's creation and its visibility to other users.
        //    optional

        //    created
        //number
        //    Creation date of the user, in .
        //required

        //    karma
        //number
        //    The user's karma.
        //    required

        //    about
        //string
        //    The user's optional self-description. HTML.
        //    optional

        //    submitted
        //array[integer]
        //List of the user's stories, polls and comments.
        //    optional
    }
}
