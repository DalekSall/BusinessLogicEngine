using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderHandling.Handlers
{
    public class MembershipHandler : AbstractHandler
    {
        private readonly IMembershipRepository membershipRepository;

        public MembershipHandler (IMembershipRepository membershipRepository)
        {
            this.membershipRepository = membershipRepository;
        }

        public async override Task<Order> HandleOrder (Order order)
        {
            var memberShips = order.Products.ToList().Where(product => product.productType == Core.Enums.ProductTypes.Membership);
            if (memberShips.Any())
            {
                await membershipRepository.ActivateMembership(order);
            }
            return await base.HandleOrder(order);
        }
    }
}
