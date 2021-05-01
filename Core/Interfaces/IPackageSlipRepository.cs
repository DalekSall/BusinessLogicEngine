using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IPackageSlipRepository
    {
        public Task<bool> CreatePackageSlip(Order order);
    }
}
