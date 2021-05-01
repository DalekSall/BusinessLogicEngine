using Core.Enums;
using Core.Interfaces;
using Core.Models;
using Moq;
using OrderHandling;
using OrderHandling.Handlers;
using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace UnitTests
{

    public class SingleBusinessOperationsTests
    {
        private OrderEngine orderEngine;


        [Fact]
        public async void ShouldCreateAPackingSlipForShippingWhenOrderContainsPhysicalProduct()
        {
            // arrange
            var order = new Order()
            {
                OrderId = "testId",
                Products = new List<Product>()
                {
                    new Product()
                    {
                        name = "testProduct",
                        productType = ProductTypes.PhysicalProduct,
                        productSubType = ProductSubTypes.None
                    }
                },
                Customer = new Customer()
                {
                    email = "k@rlo.dk"
                }
            };
            var packageSlipMock = new Mock<IPackageSlipRepository>();
            //packageSlipMock.Setup(x => x.CreatePackageSlip(order).Result
            var orderSlipHandler = new OrderSlipHandler(packageSlipMock.Object);
            var orderEngine = new OrderEngine(orderSlipHandler);

            await orderEngine.HandleOrder(order);

            packageSlipMock.Verify(mock => mock.CreatePackageSlip(order), Times.Once);
        }
    }
}
