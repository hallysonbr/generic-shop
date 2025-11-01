using GenericShop.Services.Payments.Infra.PaymentGateway.DTOs;

namespace GenericShop.Services.Payments.Infra.PaymentGateway.Interfaces
{
    public interface IPaymentGatewayService
    {
        Task<bool> Process(CreditCardInfo info);
    }
}
