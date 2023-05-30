using GenericShop.Services.Orders.Application.DTOs.InputModels;
using GenericShop.Services.Orders.Domain.Entities;
using GenericShop.Services.Orders.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericShop.Services.Orders.Application.Commands.AddOrder
{
    public class AddOrderCommand : IRequest<Guid>
    {
        public CustomerInputModel Customer { get; set; }
        public List<OrderItemInputModel> Items { get; set; }
        public DeliveryAddressInputModel DeliveryAddress { get; set; }
        public PaymentAddressInputModel PaymentAddress { get; set; }
        public PaymentInfoInputModel PaymentInfo { get; set; }

        public Order ToEntity() => new Order(
            new Customer(Customer.Id, Customer.FullName, Customer.Email),
            new DeliveryAddress(DeliveryAddress.Street, DeliveryAddress.Number, DeliveryAddress.City, DeliveryAddress.State, DeliveryAddress.ZipCode),
            new PaymentAddress(PaymentAddress.Street, PaymentAddress.Number, PaymentAddress.City, PaymentAddress.State, PaymentAddress.ZipCode),
            new PaymentInfo(PaymentInfo.CardNumber, PaymentInfo.FullName, PaymentInfo.ExpirationDate, PaymentInfo.Cvv),
            Items.Select(x => new OrderItem(x.ProductId, x.Quantity, x.Price)).ToList());
    } 
}
