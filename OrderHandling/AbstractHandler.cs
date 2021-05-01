using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderHandling
{
    public class AbstractHandler : IOrderHandler
    {
        private IOrderHandler _nextHandler;
        public async Task<IOrderHandler> SetNext(IOrderHandler handler)
        {
            _nextHandler = handler;
            return _nextHandler;
        }

        public virtual async Task<Order> HandleOrder(Order order)
        {
            if (_nextHandler != null)
            {
                return await _nextHandler.HandleOrder(order);
            }

            return null;
        }
    }
}
