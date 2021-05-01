using Core.Interfaces;
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
        private readonly IOrderEngine orderHandler;

        public OrderController(ILogger<OrderController> logger, IOrderEngine orderHandler)
        {
            _logger = logger;
            this.orderHandler = orderHandler;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {

            return new List<string>()
            {
                "hello",
                "world"
            };
        }
    }
}
