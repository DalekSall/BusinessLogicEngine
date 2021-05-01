using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogicEngine.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderEngine orderEngine;

        public OrderController(ILogger<OrderController> logger, IOrderEngine orderEngine)
        {
            _logger = logger;
            this.orderEngine = orderEngine;
        }

        [HttpPost]
        public async Task<IEnumerable<string>> Get()
        {
            // fetch from request
            var order = new Order();

            await orderEngine.HandleOrder(order);
            return new List<string>()
            {
                "hello",
                "world"
            };
        }
    }
}
