using GenericShop.Services.Payments.Infra.PaymentGateway.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericShop.Services.Payments.Infra.PaymentGateway.Interfaces
{
    public interface IPaymentGatewayService
    {
        Task<bool> Process(CreditCardInfo info);
    }
}
