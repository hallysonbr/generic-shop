using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericShop.Services.Notifications.Application.DTOs
{
    public class MailConfig
    {
        public string SendGridApiKey { get; set; }
        public string FromName { get; set; }
        public string FromEmail { get; set; }
    }
}
