using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var physicalProducts = order.Products.ToList().Where(product => product.productType == Core.Enums.ProductTypes.PhysicalProduct);
            if(physicalProducts.Any())
            {
                await packageSlipRepository.CreatePackageSlip(order);
            }
            return await base.HandleOrder(order);
        }
    }
}
