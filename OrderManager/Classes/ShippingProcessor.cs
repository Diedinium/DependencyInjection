using OrderManager.Interfaces;
using OrderManager.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager.Classes
{
    public class ShippingProcessor : IShippingProcessor
    {
        private readonly IProductStockRepository _productStockRepository;

        public ShippingProcessor(IProductStockRepository productStockRepository)
        {
            _productStockRepository = productStockRepository;
        }

        public void MailProduct(Product product)
        {
            _productStockRepository.ReduceStock(product);
            
            // Business logic would go here to determine shipping details etc..

            Console.WriteLine("Call to shipping API...");
        }
    }
}
