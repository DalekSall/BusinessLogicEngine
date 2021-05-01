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
            this._nextHandler = handler;
            return handler;
        }

        public virtual async Task<Order> HandleOrder(Order order)
        {
            if (this._nextHandler != null)
            {
                return await this._nextHandler.HandleOrder(order);
            }

            return null;
        }
    }
}
