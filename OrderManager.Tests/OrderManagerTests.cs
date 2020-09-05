using Moq;
using OrderManager.Interfaces;
using System;
using Xunit;

namespace OrderManager.Tests
{
    public class OrderManagerTests
    {
        [Fact]
        public void OrderManager_ThrowWhenNoStock()
        {
            // Arrange
            var productStockRepoMock = new Mock<IProductStockRepository>();
            productStockRepoMock
                .Setup(m => m.IsInStock(It.IsAny<Product>()))
                .Returns(false);

            var shippingProcessorMock = new Mock<IShippingProcessor>();
            var paymentProcessorMock = new Mock<IPaymentProcessor>();

            var orderManager = new OrderManager(productStockRepoMock.Object, shippingProcessorMock.Object, paymentProcessorMock.Object);

            // Act/Assert
            Assert.ThrowsAny<Exception>(() => orderManager.Submit(Product.Computer, "2424242424242424", DateTime.Parse("04/2021")));
        }

        [Fact]
        public void OrderManager_CheckStockTrue()
        {
            // Arrange
            var orderManagerMock = new Mock<IOrderManager>();
            orderManagerMock
                .Setup(m => m.CheckStock(It.IsAny<Product>()))
                .Returns(true);

            // Act

            var actual = orderManagerMock.Object.CheckStock(Product.Computer);

            // Assert
            Assert.True(actual);
        }

        [Fact]
        public void OrderManager_CheckStockFalse()
        {
            // Arrange
            var orderManagerMock = new Mock<IOrderManager>();
            orderManagerMock
                .Setup(m => m.CheckStock(It.IsAny<Product>()))
                .Returns(false);

            // Act

            var actual = orderManagerMock.Object.CheckStock(Product.Computer);

            // Assert
            Assert.False(actual);
        }

        [Fact]
        public void ProudctStockRepository_TrueWhenInStock()
        {
            // Arrange
            var productStockRepoMock = new Mock<IProductStockRepository>();
            productStockRepoMock
                .Setup(m => m.IsInStock(It.IsAny<Product>()))
                .Returns(true);

            // Act
            var result = productStockRepoMock.Object.IsInStock(Product.Mouse);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void PaymentProcessor_InvalidCardThrows()
        {
            // Arrange
            var paymentProcessorMock = new Mock<IPaymentProcessor>();
            paymentProcessorMock
                .Setup(m => m.ChargeCreditCard(It.IsAny<string>(), It.IsAny<DateTime>()))
                .Throws(new ArgumentNullException());

            // Act/Assert
            Assert.Throws<ArgumentNullException>(() => paymentProcessorMock.Object.ChargeCreditCard("teststring", DateTime.Now));
        }

        [Fact]
        public void PaymentProcessor_InvalidDateThrows()
        {
            // Arrange
            var paymentProcessorMock = new Mock<IPaymentProcessor>();
            paymentProcessorMock
                .Setup(m => m.ChargeCreditCard(It.IsAny<string>(), It.Is<DateTime>(d => d.Date < DateTime.Now.Date)))
                .Throws(new ArgumentException());

            // Act/Assert
            Assert.Throws<ArgumentException>(() => paymentProcessorMock.Object.ChargeCreditCard("teststring", DateTime.Now.AddDays(-1)));
        }
    }
}
