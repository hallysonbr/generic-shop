﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericShop.Services.Payments.Domain.Entities
{
    public class Invoice
    {
        public Invoice(decimal totalPrice, Guid orderId, string cardNumber)
        {
            this.TotalPrice = totalPrice;
            this.OrderId = orderId;
            this.CardNumber = "**-" + cardNumber.Substring(cardNumber.Length - 4);
            this.PaidAt = DateTime.Now;
        }

        public Guid Id { get; set; }
        public decimal TotalPrice { get; private set; }
        public Guid OrderId { get; private set; }
        public string CardNumber { get; private set; }
        public DateTime PaidAt { get; private set; }
    }
}
