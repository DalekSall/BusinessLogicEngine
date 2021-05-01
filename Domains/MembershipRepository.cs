using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    class MembershipRepository : IMembershipRepository
    {
    public Task<bool> ActivateMembership(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
