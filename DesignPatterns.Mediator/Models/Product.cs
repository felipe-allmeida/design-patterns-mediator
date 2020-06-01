using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Mediator.Models
{
    public class Product
    {
        private List<string> _errors;

        public Product(string name, string description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;

            _errors = new List<string>();

            if (string.IsNullOrEmpty(Name))
            {
                _errors.Add("The field Name cannot be empty");
            }

            if (string.IsNullOrEmpty(Description))
            {
                _errors.Add("The field Description cannot be empty");
            }

            if (Price <= 0)
            {
                _errors.Add("The field Price must be greater than zero");
            }
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    
        public bool IsValid()
        {
            return !_errors.Any();
        }

        public List<string> GetErrors()
        {
            return _errors;
        }
    }
}
