using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericShop.Services.Customers.Application.DTOs.ViewModels
{
    public class GetCustomerByIdViewModel
    {
        public GetCustomerByIdViewModel(Guid id, string fullName, DateTime birthDate, AddressDto address)
        {
            Id = id;
            FullName = fullName;
            BirthDate = birthDate;
            Address = address;
        }

        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public AddressDto Address { get; private set; }
    }
}
