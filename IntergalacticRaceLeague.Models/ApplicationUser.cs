using Microsoft.AspNetCore.Identity;

namespace IntergalacticRaceLeague.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; } = "";
    }
}