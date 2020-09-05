using Microsoft.Extensions.DependencyInjection;
using OrderManager.Classes;
using OrderManager.Interfaces;
using OrderManager.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager.Dependency
{
    public class ContainerBuilder
    {
        public IServiceProvider Build()
        {
            ServiceCollection container = new ServiceCollection();

            container.AddSingleton<IProductStockRepository, ProductStockRepository>();
            container.AddSingleton<IShippingProcessor, ShippingProcessor>();
            container.AddSingleton<IPaymentProcessor, PaymentProcessor>();
            container.AddSingleton<IOrderManager, OrderManager>();

            return container.BuildServiceProvider();
        }
    }
}
