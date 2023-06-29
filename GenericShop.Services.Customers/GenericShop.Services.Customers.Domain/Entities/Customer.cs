﻿using GenericShop.Services.Customers.Domain.Events;
using GenericShop.Services.Customers.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GenericShop.Services.Customers.Domain.Entities
{
    public class Customer : AggregateRoot
    {
        public Customer(Guid id, string fullName, DateTime birthDate, string email)
        {
            Id = id;
            FullName = fullName;
            BirthDate = birthDate;
            Email = email;
        }

        public string FullName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string PhoneNumber { get; private set; }
        public Address Address { get; private set; }
        public string Email { get; private set; }

        public static Customer Create(string fullName, DateTime birthDate, string email)
        {
            var customer = new Customer(Guid.NewGuid(), fullName, birthDate, email);

            customer.AddEvent(new CustomerCreated(customer.Id, customer.FullName, customer.Email));

            return customer;
        }

        private void SetAddress(Address address)
        {
            Address = address;

            AddEvent(new AddressUpdated(Id, Address.GetFullAddress()));
        }

        public void Update(string phoneNumber, Address address)
        {
            PhoneNumber = phoneNumber;
            SetAddress(address);
            AddEvent(new CustomerUpdated(Id, PhoneNumber, Address));
        }
    }
}
