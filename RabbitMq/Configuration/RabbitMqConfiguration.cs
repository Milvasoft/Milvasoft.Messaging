namespace Milvasoft.Messaging.RabbitMq.Configuration
{
    public interface IRabbitMqConfiguration
    {
        public string RabbitMqUri { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class RabbitMqConfiguration : IRabbitMqConfiguration
    {
        public string RabbitMqUri { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
