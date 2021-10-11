namespace Milvasoft.Messaging.RabbitMq.Commands
{
    public interface ISendMailCommand
    {
        #region Sender Info

        public string From { get; set; }

        public string FromPassword { get; set; }

        public int Port { get; set; }

        public string SmtpHost { get; set; }

        #endregion

        #region Mail Info

        public string To { get; set; }

        public string Subject { get; set; }

        public string HtmlBody { get; set; }

        #endregion
    }

    public class SendMailCommand : ISendMailCommand
    {
        #region Sender Info

        public string From { get; set; }

        public string FromPassword { get; set; }

        public int Port { get; set; }

        public string SmtpHost { get; set; }

        #endregion

        #region Mail Info

        public string To { get; set; }

        public string Subject { get; set; }

        public string HtmlBody { get; set; }

        #endregion
    }
}
