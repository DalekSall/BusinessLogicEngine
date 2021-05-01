using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderHandling
{
    class OrderEngine : IOrderEngine 
    {
        public OrderEngine (IEnumerable<IOrderHandler> orderHandlers)
        {

        }

        public async Task<bool> HandleOrder(Order order)
        {
            return true;
        }
    }
}
