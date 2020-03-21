
using Microsoft.AspNetCore.Identity;

namespace HackerService.DAL.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
