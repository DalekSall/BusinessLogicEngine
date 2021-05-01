using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderHandling.Handlers
{
    public class ComissionHandler : AbstractHandler
    {
        private readonly IComissionRepository comissionRepository;

        public ComissionHandler (IComissionRepository comissionRepository)
        {
            this.comissionRepository = comissionRepository;
        }

        public async override Task<Order> HandleOrder (Order order)
        {
            var productsToBeComissioned = order.Products.ToList().Where(product => product.productType == Core.Enums.ProductTypes.PhysicalProduct);
            if(productsToBeComissioned.Any())
            {
                await comissionRepository.AddComissionPayment(order);
            }
            return await base.HandleOrder(order);
        }
    }
}
