using DesignPatterns.Mediator.Data;
using DesignPatterns.Mediator.Models;
using DesignPatterns.Mediator.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DesignPatterns.Mediator.Services
{
    public class RegisterService
    {
        private readonly NotificationHandler _notificationHandler;
        private readonly MockedProductRepository _repository;

        public RegisterService(NotificationHandler notificationHandler, MockedProductRepository repository)
        {
            _notificationHandler = notificationHandler;
            _repository = repository;
        }

        public bool RegisterProduct(string name, string description, decimal price)
        {
            var product = new Product(name, description, price);

            if (!product.IsValid())
            {
                foreach(var error in product.GetErrors())
                {
                    _notificationHandler.PublishNotification(error);
                }
                return false;
            }

            return Commit(product);
        }

        private bool Commit(Product product)
        {
            if (!_repository.AddProduct(product))
            {
                _notificationHandler.PublishNotification("Commit failed");
                return false;
            }
            return true;
        }
    }
}
