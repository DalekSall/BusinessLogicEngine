using Core.Enums;
using Core.Interfaces;
using Core.Models;
using Moq;
using OrderHandling;
using OrderHandling.Handlers;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace UnitTests
{

    public class SingleBusinessOperationsTests
    {
        // assuming the package slip repo knows where the slip should go
        // we use the same repo, but will configure it differently in DIC
        private Mock<IPackageSlipRepository> packageSlipMock;
        private Mock<IPackageSlipRepository> royaltySlipMock;
        private async Task<OrderEngine> CreateOrderEngine()
        {
            packageSlipMock = new Mock<IPackageSlipRepository>();
            royaltySlipMock = new Mock<IPackageSlipRepository>();
            var orderSlipHandler = new OrderSlipHandler(packageSlipMock.Object);
            var royaltySlipHandler = new RoyaltySlipHandler(royaltySlipMock.Object);

            await royaltySlipHandler.SetNext(orderSlipHandler);
            return new OrderEngine(royaltySlipHandler);
        }

        private async Task<Order> CreateOrder(ProductTypes productType, ProductSubTypes productSubType)
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
            var order = await CreateOrder(ProductTypes.PhysicalProduct, ProductSubTypes.None);

            // act
            var orderEngine = await CreateOrderEngine();
            await orderEngine.HandleOrder(order);

            // assert
            packageSlipMock.Verify(mock => mock.CreatePackageSlip(order), Times.Once);
        }

        [Fact]
        public async void ShouldNotCreatePackingSlipForShippingWhenOrderDoesNotContainPhysicalProduct()
        {
            // arrange
            var order = await CreateOrder(ProductTypes.Membership, ProductSubTypes.None);

            // act
            var orderEngine = await CreateOrderEngine();
            await orderEngine.HandleOrder(order);

            // assert
            packageSlipMock.Verify(mock => mock.CreatePackageSlip(order), Times.Never);
        }

        [Fact]
        public async void ShouldCreatePackingSlipForBothRoyaltyDepartmentAndCustomerIfPhysicalProductIsABook()
        {
            // arrange
            var order = await CreateOrder(ProductTypes.PhysicalProduct, ProductSubTypes.None);

            // act
            var orderEngine = await CreateOrderEngine();
            await orderEngine.HandleOrder(order);

            // assert
            packageSlipMock.Verify(mock => mock.CreatePackageSlip(order), Times.Once);
            royaltySlipMock.Verify(mock => mock.CreatePackageSlip(order), Times.Once);
        }
    }
}
