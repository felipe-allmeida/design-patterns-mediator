using DesignPatterns.Mediator.Data;
using DesignPatterns.Mediator.Models;
using DesignPatterns.Mediator.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Mediator.Services
{
    public class RentService
    {
        private readonly NotificationHandler _notificationHandler;
        private readonly MockedProductRepository _repository;

        public RentService(NotificationHandler notificationHandler, MockedProductRepository repository)
        {
            _notificationHandler = notificationHandler;
            _repository = repository;
        }

        public Product RentProduct(string name)
        {
            var product = _repository.GetProduct(name);

            if (product == null)
            {
                _notificationHandler.PublishNotification("Product is not available");
            }

            return product;
        }
    }
}
