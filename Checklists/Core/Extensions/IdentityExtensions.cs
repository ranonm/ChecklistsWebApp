using System.Security.Claims;

namespace Checklists.Core.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetFullName(this System.Security.Principal.IPrincipal user)
        {
            var fullNameClaim = ((ClaimsIdentity)user.Identity).FindFirst("FullName");
            return fullNameClaim != null ? fullNameClaim.Value : string.Empty;
        }
    }
}