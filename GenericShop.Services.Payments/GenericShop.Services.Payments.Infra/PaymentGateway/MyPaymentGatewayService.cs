using GenericShop.Services.Payments.Infra.PaymentGateway.DTOs;
using GenericShop.Services.Payments.Infra.PaymentGateway.Interfaces;

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
