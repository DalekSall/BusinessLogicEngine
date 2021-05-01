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
        private Mock<IPackageSlipRepository> packageSlipMock;
        private OrderEngine CreateOrderEngine()
        {
            this.packageSlipMock = new Mock<IPackageSlipRepository>();
            var orderSlipHandler = new OrderSlipHandler(packageSlipMock.Object);

            return new OrderEngine(orderSlipHandler);
        }

        private Order CreateOrder(ProductTypes productType, ProductSubTypes productSubType)
        {
            return new Order()
            {
                OrderId = "testId",
                Products = new List<Product>()
                {
                    new Product()
                    {
                        name = "testProduct",
                        productType = productType,
                        productSubType = productSubType
                    }
                },
                Customer = new Customer()
                {
                    email = "k@rlo.dk"
                }
            };
        }

        [Fact]
        public async void ShouldCreateAPackingSlipForShippingWhenOrderContainsPhysicalProduct()
        {
            // arrange
            var order = this.CreateOrder(ProductTypes.PhysicalProduct, ProductSubTypes.None);

            // act
            await this.CreateOrderEngine().HandleOrder(order);

            // assert
            this.packageSlipMock.Verify(mock => mock.CreatePackageSlip(order), Times.Once);
        }

        [Fact]
        public async void ShouldNotCreatePackingSlipForShippingWhenOrderDoesNotContainPhysicalProduct()
        {
            // arrange
            var order = this.CreateOrder(ProductTypes.Membership, ProductSubTypes.None);

            await this.CreateOrderEngine().HandleOrder(order);

            this.packageSlipMock.Verify(mock => mock.CreatePackageSlip(order), Times.Never);
        }
    }
}
