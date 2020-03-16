using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace RssFeeder.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<RssLink> RssLinks { get; set; }
    }
}
