using GenericShop.Services.Payments.Infra.PaymentGateway.DTOs;
using GenericShop.Services.Payments.Infra.PaymentGateway.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericShop.Services.Payments.Infra.PaymentGateway
{
    public class MyPaymentGatewayService : IPaymentGatewayService
    {
        public Task<bool> Process(CreditCardInfo info)
        {
            return Task.FromResult(true);
        }
    }
}
