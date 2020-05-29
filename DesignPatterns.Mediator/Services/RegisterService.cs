using DesignPatterns.Mediator.Data;
using DesignPatterns.Mediator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DesignPatterns.Mediator.Services
{
    public class RegisterService
    {
        private readonly MockedProductRepository _repository;
        private List<Product> _products;

        public RegisterService(MockedProductRepository repository)
        {
            _products = new List<Product>();
            _repository = repository;
        }

        public List<string> RegisterProduct(string name, string description, decimal price)
        {
            var product = new Product(name, description, price);

            if (product.IsValid())
            {
                return product.GetErrors();
            }            

            return new List<string>();
        }

        private string Commit(Product product)
        {
            if (!_repository.AddProduct(product))
            {
                return "Commit failed";
            }

            return string.Empty;
        }
    }
}
