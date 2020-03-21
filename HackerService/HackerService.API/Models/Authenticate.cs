using System.ComponentModel.DataAnnotations;


namespace HackerService.API.Models
{
    public class Authenticate
    {
        public class AuthenticateModel
        {
            [Required]
            public string Username { get; set; }

            [Required]
            public string Password { get; set; }
        }
    }
}
