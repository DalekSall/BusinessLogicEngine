using OrderHandling;
using System;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace UnitTests
{

    public class SingleBusinessOperationsTests
    {
        private OrderEngine orderEngine;

        [Fact]
        public void ShouldCreateAPackingSlipForShippingWhenOrderContainsPhysicalProduct()
        {
            // arrange
        }
    }
}
