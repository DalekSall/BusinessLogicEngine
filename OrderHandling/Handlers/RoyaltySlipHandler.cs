using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderHandling.Handlers
{
    public class RoyaltySlipHandler : AbstractHandler
    {
        private readonly IPackageSlipRepository packageSlipRepository;

        public RoyaltySlipHandler (IPackageSlipRepository packageSlipRepository)
        {
            this.packageSlipRepository = packageSlipRepository;
        }

        public async override Task<Order> HandleOrder (Order order)
        {
            var books = order.Products.ToList().Where(product => 
                product.productType == Core.Enums.ProductTypes.PhysicalProduct &&
                product.productSubType == Core. Enums.ProductSubTypes.Book );
            if(books.Any())
            {
                await packageSlipRepository.CreatePackageSlip(order);
            }
            return await base.HandleOrder(order);
        }
    }
}
