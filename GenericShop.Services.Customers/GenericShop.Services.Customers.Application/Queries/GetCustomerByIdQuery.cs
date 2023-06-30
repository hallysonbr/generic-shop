using GenericShop.Services.Customers.Application.DTOs.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericShop.Services.Customers.Application.Queries
{
    public class GetCustomerByIdQuery : IRequest<GetCustomerByIdViewModel>
    {
        public GetCustomerByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
