using System.Collections.Generic;
using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.ClaimSecurityTesting.Models
{
    public class Policy : AggregateRoot<long>
    {
        public IReadOnlyCollection<RequiredClaim> RequiredClaims { get; }

        public Policy(IReadOnlyCollection<RequiredClaim> requiredClaims, long id) : base(id)
        {
            Guard.ObjectNotNull(() => requiredClaims);

            RequiredClaims = requiredClaims;
        }
    }
}