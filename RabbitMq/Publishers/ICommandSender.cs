using Milvasoft.Messaging.RabbitMq.Commands;
using System.Threading.Tasks;

namespace Milvasoft.Messaging.RabbitMq.Publishers;

/// <summary>
/// Provides ready-written publish methods of commands in milvasoft messaging library.
/// </summary>
public interface ICommandSender
{
    /// <summary>
    /// Publish <paramref name="sendMailCommand"/> command to <see cref="RabbitMqConstants.MailServiceQueueName"/> queue.
    /// </summary>
    /// <param name="sendMailCommand"></param>
    /// <returns></returns>
    Task PublishSendMailCommandAsync(ISendMailCommand sendMailCommand);

    /// <summary>
    /// Publish <paramref name="logAuditCommand"/> command to <see cref="RabbitMqConstants.AuditServiceQueueName"/> queue.
    /// </summary>
    /// <param name="logAuditCommand"></param>
    /// <returns></returns>
    Task PublishLogAuditCommandAsync(ILogAuditCommand logAuditCommand);

    /// <summary>
    /// Publish <paramref name="addNotificationCommand"/> command to <see cref="RabbitMqConstants.NotificationServiceQueueName"/> queue.
    /// </summary>
    /// <param name="addNotificationCommand"></param>
    /// <returns></returns>
    Task PublishAddNotificationCommandAsync(IAddNotificationCommand addNotificationCommand);

    /// <summary>
    /// Publish <paramref name="sendPushCommand"/> command to <see cref="RabbitMqConstants.PushServiceQueueName"/> queue.
    /// </summary>
    /// <param name="sendPushCommand"></param>
    /// <returns></returns>
    Task PublishSendPushCommandAsync(ISendPushCommand sendPushCommand);
}
