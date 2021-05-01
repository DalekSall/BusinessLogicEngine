using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public class MembershipRepository : IMembershipRepository
    {
        public async Task<bool> ActivateMembership(Order order)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpgradeMembership(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
