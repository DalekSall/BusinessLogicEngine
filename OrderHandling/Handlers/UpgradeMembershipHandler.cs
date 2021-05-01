using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderHandling.Handlers
{
    public class UpgradeMembershipHandler : AbstractHandler
    {
        private readonly IMembershipRepository membershipRepository;
        private readonly IEmailRepository emailRepository;

        public UpgradeMembershipHandler (IMembershipRepository membershipRepository, IEmailRepository emailRepository)
        {
            this.membershipRepository = membershipRepository;
            this.emailRepository = emailRepository;
        }

        public async override Task<Order> HandleOrder (Order order)
        {
            var upgrades = order.Products.ToList().Where( product => 
                product.productType == Core.Enums.ProductTypes.Membership &&
                product.productSubType == Core.Enums.ProductSubTypes.Upgrade
            );

            if(upgrades.Any())
            {
                await handleUpgrade(order);
            }
            
            return await base.HandleOrder(order);
        }

        private async Task<bool> handleUpgrade(Order order)
        {
            var upgraded = await membershipRepository.UpgradeMembership(order);
            if(upgraded)
            {
                return await emailRepository.SendUpgradeMail(order);
            }

            return false;
        }
    }
}
