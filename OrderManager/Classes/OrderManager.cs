using OrderManager.Classes;
using OrderManager.Interfaces;
using OrderManager.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager
{
    public class OrderManager : IOrderManager
    {
        private readonly IProductStockRepository _productStockRepository;
        private readonly IShippingProcessor _shippingProcessor;
        private readonly IPaymentProcessor _paymentProcessor;

        public OrderManager(IProductStockRepository productStockRepository, IShippingProcessor shippingProcessor, IPaymentProcessor paymentProcessor)
        {
            _productStockRepository = productStockRepository;
            _shippingProcessor = shippingProcessor;
            _paymentProcessor = paymentProcessor;
        }

        public void Submit(Product product, string cardNumber, DateTime cardExpiryDate)
        {
            // Check product stock
            if (!_productStockRepository.IsInStock(product))
            {
                throw new Exception($"{product} is currently not in stock");
            }

            // Payment
            _paymentProcessor.ChargeCreditCard(cardNumber, cardExpiryDate);

            // Ship the product
            _shippingProcessor.MailProduct(product);
        }

        public bool CheckStock(Product product)
        {
            return _productStockRepository.IsInStock(product);
        }
    }
}
