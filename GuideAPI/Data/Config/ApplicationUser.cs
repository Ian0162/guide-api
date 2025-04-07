using Microsoft.AspNetCore.Identity;

namespace GuideAPI.Data.Config
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
