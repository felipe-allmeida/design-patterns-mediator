using DesignPatterns.Mediator.Data;
using DesignPatterns.Mediator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Mediator.Services
{
    public class RentService
    {
        private readonly MockedProductRepository _repository;

        public RentService(MockedProductRepository repository)
        {
            _repository = repository;
        }

        public (Product, string error) RentProduct(string name)
        {
            var product = _repository.GetProduct(name);

            if (product == null)
            {
                return (null, "Product not avaiable for rent");
            }

            return (product, string.Empty);
        }
    }
}
