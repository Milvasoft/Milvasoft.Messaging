namespace Milvasoft.Messaging.RabbitMq.Commands;

/// <summary>
/// Model required for sending mail.
/// </summary>
public interface ISendMailCommand
{
    #region Sender Info

    /// <summary>
    /// The e-mail address of the sender
    /// </summary>
    public string From { get; set; }

    /// <summary>
    /// Password of the e-mail address that sent the e-mail
    /// </summary>
    public string FromPassword { get; set; }

    /// <summary>
    /// Specifies which port the mail will be forwarded with.
    /// </summary>
    public int Port { get; set; }

    /// <summary>
    /// Specifies which host the mail will be forwarded with.
    /// </summary>
    public string SmtpHost { get; set; }

    /// <summary>
    /// Gets or sets enable ssql of mail sender smtp client.
    /// </summary>
    public bool EnableSsl { get; set; }

    #endregion

    #region Mail Info

    /// <summary>
    /// The e-mail address to which the mail will be sent.
    /// </summary>
    public string To { get; set; }

    /// <summary>
    /// Subject of mail.
    /// </summary>
    public string Subject { get; set; }

    /// <summary>
    /// Html content of mail.
    /// </summary>
    public string HtmlBody { get; set; }

    #endregion
}

/// <summary>
/// Model required for sending mail.
/// </summary>
public class SendMailCommand : ISendMailCommand
{
    #region Sender Info

    /// <summary>
    /// The e-mail address of the sender
    /// </summary>
    public string From { get; set; }

    /// <summary>
    /// Password of the e-mail address that sent the e-mail
    /// </summary>
    public string FromPassword { get; set; }

    /// <summary>
    /// Specifies which port the mail will be forwarded with.
    /// </summary>
    public int Port { get; set; }

    /// <summary>
    /// Specifies which host the mail will be forwarded with.
    /// </summary>
    public string SmtpHost { get; set; }

    /// <summary>
    /// Gets or sets enable ssql of mail sender smtp client.
    /// </summary>
    public bool EnableSsl { get; set; }

    #endregion

    #region Mail Info

    /// <summary>
    /// The e-mail address to which the mail will be sent.
    /// </summary>
    public string To { get; set; }

    /// <summary>
    /// Subject of mail.
    /// </summary>
    public string Subject { get; set; }

    /// <summary>
    /// Html content of mail.
    /// </summary>
    public string HtmlBody { get; set; }

    #endregion
}
