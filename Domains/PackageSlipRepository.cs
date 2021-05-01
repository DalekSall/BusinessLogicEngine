using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public class PackageSlipRepository : IPackageSlipRepository
    {
        public Task<bool> CreatePackageSlip()
        {
            throw new NotImplementedException();
        }
    }
}
