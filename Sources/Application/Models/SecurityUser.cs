using System.Collections.Generic;

namespace Mmu.ClaimSecurityTesting.Models
{
    public class SecurityUser : SecurityPrincipal
    {
        public SecurityUser(IReadOnlyCollection<Claim> claims, string id) : base(claims, id)
        {
        }
    }
}