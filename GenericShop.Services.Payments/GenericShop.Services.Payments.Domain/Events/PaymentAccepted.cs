using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericShop.Services.Payments.Domain.Events
{
    public class PaymentAccepted
    {
        public PaymentAccepted(Guid id, string fullName, string email)
        {
            this.Id = id;
            this.FullName = fullName;
            this.Email = email;
        }

        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
