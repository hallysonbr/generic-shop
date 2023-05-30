﻿using GenericShop.Services.Orders.Domain.Interfaces.Events;
using GenericShop.Services.Orders.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericShop.Services.Orders.Domain.Events
{
    public class OrderCreated : IDomainEvent
    {
        public OrderCreated(Guid id, decimal totalPrice, PaymentInfo paymentInfo, string fullName, string email)
        {
            Id = id;
            TotalPrice = totalPrice;
            PaymentInfo = paymentInfo;
            FullName = fullName;
            Email = email;
        }

        public Guid Id { get; }
        public decimal TotalPrice { get; }
        public PaymentInfo PaymentInfo { get; }
        public string FullName { get; }
        public string Email { get; }
    }
}
