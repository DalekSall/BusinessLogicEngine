using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderHandling.Handlers
{
    public class OrderSlipHandler : AbstractHandler
    {
        private readonly IPackageSlipRepository packageSlipRepository;

        public OrderSlipHandler (IPackageSlipRepository packageSlipRepository)
        {
            this.packageSlipRepository = packageSlipRepository;
        }

        public async override Task<Order> HandleOrder (Order order)
        {
            await this.packageSlipRepository.CreatePackageSlip(order);
            return order;
        }
    }
}
