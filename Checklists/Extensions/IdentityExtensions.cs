using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Checklists.Extensions
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