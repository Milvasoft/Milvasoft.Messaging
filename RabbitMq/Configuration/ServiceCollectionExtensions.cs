using Microsoft.Extensions.DependencyInjection;
using Milvasoft.Messaging.RabbitMq.Publishers;
using System;

namespace Milvasoft.Messaging.RabbitMq.Configuration
{
    /// <summary>
    /// Service collection helpers for rabbitmq messaging.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds <see cref="RabbitMqBusConfigurator"/>, <see cref="RabbitMqConfiguration"/> and <see cref="CommandSender"/> to service collection as singleton.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="rabbitMqConfigurationAction"></param>
        /// <returns></returns>
        public static IServiceCollection AddMilvaMessaging(this IServiceCollection services, Action<IRabbitMqConfiguration> rabbitMqConfigurationAction)
        {
            var config = new RabbitMqConfiguration();

            rabbitMqConfigurationAction.Invoke(config);

            services.AddSingleton<IRabbitMqConfiguration>(config);

            services.AddSingleton<IRabbitMqBusConfigurator, RabbitMqBusConfigurator>();

            services.AddSingleton<ICommandSender, CommandSender>();

            return services;
        }
    }
}
