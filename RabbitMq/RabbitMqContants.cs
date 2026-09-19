namespace Milvasoft.Messaging.RabbitMq;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public static class RabbitMqConstants
{
    public const string MailServiceQueueName = "mail.service";
    public const string AuditServiceQueueName = "audit.service";
    public const string InvoiceService = "invoice.service";
    public const string NotificationServiceQueueName = "notification.service";
    public const string PushServiceQueueName = "push.service";
    public const string RemovePushTokensQueueNamePrefix = "push.remove-tokens.";

    /// <summary>
    /// Queue that collects the device tokens Firebase rejected for pushes sent with the given configuration key
    /// (<see cref="Commands.IRemovePushTokensCommand.ConfigurationKey"/>, the key the producer put on the push). Each app
    /// that owns device tokens drains the queue of its own key; an empty key maps to <c>default</c>.
    /// </summary>
    /// <param name="configurationKey"></param>
    /// <returns></returns>
    public static string GetRemovePushTokensQueueName(string configurationKey)
        => $"{RemovePushTokensQueueNamePrefix}{(string.IsNullOrWhiteSpace(configurationKey) ? "default" : configurationKey.Trim().ToLowerInvariant())}";
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
