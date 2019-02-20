using System.Collections.Generic;
using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.ClaimSecurityTesting.Models
{
    public class RequiredClaim : ValueObject<RequiredClaim>
    {
        public IReadOnlyCollection<string> AllowedValues { get; }
        public string ClaimType { get; }

        public RequiredClaim(string claimType, params string[] allowedValues)
        {
            Guard.StringNotNullOrEmpty(() => claimType);
            Guard.ObjectNotNull(() => allowedValues);

            ClaimType = claimType;
            AllowedValues = allowedValues;
        }
    }
}