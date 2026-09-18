namespace Milvasoft.Messaging.RabbitMq.Commands;

/// <summary>
/// Model required for sending mail.
/// </summary>
public interface ISendMailCommand
{
    #region Sender Info

    /// <summary>
    /// Name of the SMTP profile configured on the mail service (<c>Mail:Profiles</c>). When it is set the mail
    /// service uses that profile and IGNORES the sender fields above, so the publisher does not need to know or
    /// send any SMTP credentials. Leave it empty to keep sending the sender info with the message (legacy).
    /// </summary>
    public string ConfigurationKey { get; set; }

    /// <summary>
    /// The display name of the sender
    /// </summary>
    public string DisplayName { get; set; }

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

    /// <summary>
    /// The e-mail address of the sender
    /// </summary>
    public string Sender { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the default credentials are used to access the SMTP server.
    /// </summary>
    public bool? UseCredentials { get; set; }

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
    /// Name of the SMTP profile configured on the mail service (<c>Mail:Profiles</c>). When it is set the mail
    /// service uses that profile and IGNORES the sender fields above, so the publisher does not need to know or
    /// send any SMTP credentials. Leave it empty to keep sending the sender info with the message (legacy).
    /// </summary>
    public string ConfigurationKey { get; set; }

    /// <summary>
    /// The display name of the sender
    /// </summary>
    public string DisplayName { get; set; }

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

    /// <summary>
    /// The e-mail address of the sender
    /// </summary>
    public string Sender { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the default credentials are used to access the SMTP server.
    /// </summary>
    public bool? UseCredentials { get; set; }

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
