using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager.Interfaces
{
    public interface IProductStockRepository
    {
        bool IsInStock(Product product);
        void ReduceStock(Product product);
        void AddStock(Product product);
    }
}
