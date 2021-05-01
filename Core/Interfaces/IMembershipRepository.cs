using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IMembershipRepository
    {
        public Task<bool> ActivateMembership(Order order);
    }
}
