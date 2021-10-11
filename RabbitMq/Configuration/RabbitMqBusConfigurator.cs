using MassTransit;
using MassTransit.RabbitMqTransport;
using System;

namespace Milvasoft.Messaging.RabbitMq.Configuration
{
    /// <summary>
    /// Bus factory for rabbitMq.
    /// </summary>
    public interface IRabbitMqBusConfigurator
    {
        /// <summary>
        /// Creates rabbitMq bus with mass transit bus factory.
        /// </summary>
        /// <param name="registrationAction"></param>
        /// <returns></returns>
        IBusControl CreateBus(Action<IRabbitMqBusFactoryConfigurator> registrationAction = null);

        /// <summary>
        /// Get rabbitMq uri from <see cref="IRabbitMqConfiguration"/>.
        /// </summary>
        /// <returns></returns>
        string GetRabbitMqUri();
    }

    /// <summary>
    /// Bus factory for rabbitMq.
    /// </summary>
    public class RabbitMqBusConfigurator : IRabbitMqBusConfigurator
    {
        private readonly IRabbitMqConfiguration _rabbitMqConfiguration;

        /// <summary>
        /// Initializes new instance of <see cref="RabbitMqBusConfigurator"/>
        /// </summary>
        /// <param name="rabbitMqConfiguration"></param>
        public RabbitMqBusConfigurator(IRabbitMqConfiguration rabbitMqConfiguration)
        {
            _rabbitMqConfiguration = rabbitMqConfiguration;
        }

        /// <summary>
        /// Creates rabbitMq bus with mass transit bus factory.
        /// </summary>
        /// <param name="registrationAction"></param>
        /// <returns></returns>
        public IBusControl CreateBus(Action<IRabbitMqBusFactoryConfigurator> registrationAction = null)
            => Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(new Uri(_rabbitMqConfiguration.RabbitMqUri), hst =>
                {
                    hst.Username(_rabbitMqConfiguration.UserName);
                    hst.Password(_rabbitMqConfiguration.Password);
                });

                registrationAction?.Invoke(cfg);
            });

        /// <summary>
        /// Get rabbitMq uri from <see cref="IRabbitMqConfiguration"/>.
        /// </summary>
        /// <returns></returns>
        public string GetRabbitMqUri() => _rabbitMqConfiguration.RabbitMqUri;
    }
}
