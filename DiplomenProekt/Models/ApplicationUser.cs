using Microsoft.AspNetCore.Identity;

namespace DiplomenProekt.Models
{
    public class ApplicationUser : IdentityUser
    {
        public bool HasPaidSubscription { get; set; }
    }
}
