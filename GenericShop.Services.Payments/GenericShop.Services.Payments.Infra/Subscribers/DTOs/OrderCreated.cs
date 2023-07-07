using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericShop.Services.Payments.Infra.Subscribers.DTOs
{
    public class OrderCreated
    {
        public Guid Id { get; set; }
        public decimal TotalPrice { get; set; }
        public PaymentInfo PaymentInfo { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
