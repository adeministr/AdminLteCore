using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Naitzel.Intranet.Domain.AdminLte.Entities
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string AvatarURL { get; set; }

        public virtual string Password { get; set; }
    }
}