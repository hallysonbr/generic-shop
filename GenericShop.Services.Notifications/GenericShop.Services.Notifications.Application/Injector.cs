using GenericShop.Services.Notifications.Application.DTOs;
using GenericShop.Services.Notifications.Application.Interfaces.Services;
using GenericShop.Services.Notifications.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SendGrid.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericShop.Services.Notifications.Application
{
    public static class Injector
    {
        public static void AddMailService(this IServiceCollection services, IConfiguration configuration)
        {
            var config = new MailConfig();

            configuration.GetSection("Notifications").Bind(config);

            services.AddSingleton<MailConfig>(m => config);

            services.AddSendGrid(sp => sp.ApiKey = config.SendGridApiKey);

            services.AddTransient<INotificationService, NotificationService>();           
        }
    }
}
