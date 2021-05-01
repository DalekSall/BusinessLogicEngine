using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderHandling.Handlers
{
    public class ActivateMembershipHandler : AbstractHandler
    {
        private readonly IMembershipRepository membershipRepository;
        private readonly IEmailRepository emailRepository;

        public ActivateMembershipHandler (IMembershipRepository membershipRepository, IEmailRepository emailRepository)
        {
            this.membershipRepository = membershipRepository;
            this.emailRepository = emailRepository;
        }

        public async override Task<Order> HandleOrder(Order order)
        {
            var memberShips = order.Products.ToList().Where(product =>
               product.productType == Core.Enums.ProductTypes.Membership &&
               product.productSubType != Core.Enums.ProductSubTypes.Upgrade
            );

            if (memberShips.Any())
            {
                await handleActivation(order);

            }
            return await base.HandleOrder(order);
        }
        private async Task<bool> handleActivation (Order order)
        {
            var activated = await membershipRepository.ActivateMembership(order);
            if(activated)
            {
                return await emailRepository.SendActivationMail(order);
            }

            return false;
        }
    }
}
