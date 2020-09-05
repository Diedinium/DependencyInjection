using OrderManager.Classes;
using OrderManager.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager
{
    public class OrderManager
    {
        public void Submit(Product product, string cardNumber, DateTime cardExpiryDate)
        {
            // Check product stock
            var productStockRepo = new ProductStockRepository();

            if (!productStockRepo.IsInStock(product))
            {
                throw new Exception($"{product} is currently not in stock");
            }

            // Payment
            var paymentProcessor = new PaymentProcessor();
            paymentProcessor.ChargeCreditCard(cardNumber, cardExpiryDate);

            // Ship the product
            var shippingProcessor = new ShippingProcessor();
            shippingProcessor.MailProduct(product);
        }
    }
}
