using DesignPatterns.Mediator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Mediator.Data
{
    public class MockedProductRepository
    {
        private static List<Product> _products;

        public MockedProductRepository(List<Product> products)
        {
            _products = products;
        }

        public bool AddProduct(Product product)
        {
            var success = new Random().Next(0, 10) > 5;

            if (success)
            {
                _products.Add(product);
                return true;
            }

            return false;
        }

        public Product GetProduct(string name)
        {
            return _products.FirstOrDefault(x => x.Name == name);
        }

        public List<Product> GetAll()
        {
            return _products;
        }
    }
}
