using Microsoft.AspNetCore.Identity;

namespace NationalParks.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }

    }
}
