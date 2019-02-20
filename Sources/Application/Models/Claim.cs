using System.Collections.Generic;
using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.ClaimSecurityTesting.Models
{
    public class Claim : ValueObject<Claim>
    {
        public string ClaimType { get; }
        public IReadOnlyCollection<string> Values { get; }

        public Claim(string claimType, params string[] values)
        {
            Guard.StringNotNullOrEmpty(() => claimType);
            Guard.ObjectNotNull(() => values);

            ClaimType = claimType;
            Values = values;
        }
    }
}