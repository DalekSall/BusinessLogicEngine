using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderHandling
{
    public class OrderEngine : IOrderEngine 
    {

        private IOrderHandler orderHandlerChain;
        public OrderEngine (IOrderHandler orderHandlerChain)
        {
            this.orderHandlerChain = orderHandlerChain;
        }

        public async Task<bool> HandleOrder(Order order)
        {
            if(orderHandlerChain != null)
            {
                await orderHandlerChain.HandleOrder(order);
            }
            return true;
        }
    }
}
