using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public class PackageSlipRepository : IPackageSlipRepository
    {
        public Task<bool> CreatePackageSlip(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
