using System.Collections.Generic;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace ConsoleApp23.Models
{
    public class SecurityGroup : SecurityPrincipal
    {
        public IReadOnlyCollection<SecurityUser> Users { get; }

        public SecurityGroup(IReadOnlyCollection<SecurityUser> users, IReadOnlyCollection<Claim> claims, string id) : base(claims, id)
        {
            Guard.ObjectNotNull(() => users);

            Users = users;
        }
    }
}