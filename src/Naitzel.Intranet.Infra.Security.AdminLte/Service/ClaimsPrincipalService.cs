using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

using Naitzel.Intranet.Domain.AdminLte.Common;
using Naitzel.Intranet.Domain.AdminLte.Entities;

namespace Naitzel.Intranet.Infra.Security.AdminLte.Service
{
    public class ClaimsPrincipalService : UserClaimsPrincipalFactory<User, Role>
    {
        public ClaimsPrincipalService(
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IOptions<IdentityOptions> optionsAccessor) : base(userManager, roleManager, optionsAccessor) { }

        public override async Task<ClaimsPrincipal> CreateAsync(User user)
        {
            var principal = await base.CreateAsync(user);

            ((ClaimsIdentity) principal.Identity).AddClaims(new []
            {
                new Claim(CustomClaimTypes.GivenName, user.FirstName),
                    new Claim(CustomClaimTypes.Surname, user.LastName),
                    new Claim(CustomClaimTypes.AvatarURL, user.AvatarURL ?? "/images/user.png"),
                    new Claim(CustomClaimTypes.NickName, user.UserName),
            });

            return principal;
        }
    }
}