using System.Collections.Generic;
using System.Linq;
using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.ClaimSecurityTesting.Models
{
    /// <summary>
    ///     Basic representation of an object, that can be authenticated and identified
    /// </summary>
    public abstract class SecurityPrincipal : AggregateRoot<string>
    {
        public IReadOnlyCollection<Claim> Claims { get; }

        protected SecurityPrincipal(IReadOnlyCollection<Claim> claims, string id) : base(id)
        {
            Guard.ObjectNotNull(() => claims);

            Claims = claims;
        }

        public bool CanFullfill(IReadOnlyCollection<RequiredClaim> requiredClaims)
        {
            foreach (var reqClaim in requiredClaims)
            {
                var isFullfilled = Claims.Any(
                    claim =>
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