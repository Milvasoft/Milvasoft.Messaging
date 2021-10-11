namespace Milvasoft.Messaging.RabbitMq.Configuration
{
    /// <summary>
    /// Required information to connect to RabbitMq server.
    /// </summary>
    public interface IRabbitMqConfiguration
    {
        /// <summary>
        /// Uri of RabbitMq server.
        /// </summary>
        public string RabbitMqUri { get; set; }

        /// <summary>
        /// UserName of RabbitMq server user.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Password of RabbitMq server user.
        /// </summary>
        public string Password { get; set; }
    }

    /// <summary>
    /// Required information to connect to RabbitMq server.
    /// </summary>
    public class RabbitMqConfiguration : IRabbitMqConfiguration
    {
        /// <summary>
        /// Uri of RabbitMq server.
        /// </summary>
        public string RabbitMqUri { get; set; }

        /// <summary>
        /// UserName of RabbitMq server user.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Password of RabbitMq server user.
        /// </summary>
        public string Password { get; set; }
    }
}
