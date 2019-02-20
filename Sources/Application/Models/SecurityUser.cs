using System.Collections.Generic;
using System.Linq;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;

namespace Mmu.ClaimSecurityTesting.Models
{
    public class SecurityUser : SecurityPrincipal
    {
        public SecurityUser(IReadOnlyCollection<Claim> claims, string id) : base(claims, id)
        {
        }

        public override bool CanFullfill(IReadOnlyCollection<RequiredClaim> requiredClaims)
        {
            foreach(var reqClaim in requiredClaims)
            {
                var isFullfilled = Claims.Any(claim =>
                claim.ClaimType == reqClaim.ClaimType &&
                claim.Values.ContainsAny(reqClaim.AllowedValues));

                if (!isFullfilled)
                {
                    return false;
                }
            }

            return true;
        }
    }
}