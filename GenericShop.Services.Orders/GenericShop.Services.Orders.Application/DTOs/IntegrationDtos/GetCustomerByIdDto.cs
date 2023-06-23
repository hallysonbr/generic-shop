using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace GenericShop.Services.Orders.Application.DTOs.IntegrationDtos
{
    public class GetCustomerByIdDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public AddressDto Address { get; set; }
    }
}
