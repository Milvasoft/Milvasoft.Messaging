using Milvasoft.Messaging.RabbitMq.Commands;
using Milvasoft.Messaging.RabbitMq.Configuration;
using System;
using System.Threading.Tasks;

namespace Milvasoft.Messaging.RabbitMq.Publishers;

/// <summary>
/// Provides ready-written publish methods of commands in milvasoft messaging library.
/// </summary>
/// <remarks>
/// Initializes new instance of <see cref="CommandSender"/>.
/// </remarks>
/// <param name="rabbitMqConfigurator"></param>
public class CommandSender(IRabbitMqBusConfigurator rabbitMqConfigurator) : ICommandSender
{
    private readonly IRabbitMqBusConfigurator _rabbitMqConfigurator = rabbitMqConfigurator;

    /// <summary>
    /// Publish <paramref name="sendMailCommand"/> command to <see cref="RabbitMqConstants.MailServiceQueueName"/> queue.
    /// </summary>
    /// <param name="sendMailCommand"></param>
    /// <returns></returns>
    public async Task PublishSendMailCommandAsync(ISendMailCommand sendMailCommand)
    {
        var bus = _rabbitMqConfigurator.CreateBus();

        var sendToUri = new Uri($"{_rabbitMqConfigurator.GetRabbitMqUri()}{RabbitMqConstants.MailServiceQueueName}");

        var endPoint = await bus.GetSendEndpoint(sendToUri).ConfigureAwait(false);

        await endPoint.Send(sendMailCommand).ConfigureAwait(false);
    }

    /// <summary>
    /// Publish <paramref name="logAuditCommand"/> command to <see cref="RabbitMqConstants.AuditServiceQueueName"/> queue.
    /// </summary>
    /// <param name="logAuditCommand"></param>
    /// <returns></returns>
    public async Task PublishLogAuditCommandAsync(ILogAuditCommand logAuditCommand)
    {
        var bus = _rabbitMqConfigurator.CreateBus();

        var sendToUri = new Uri($"{_rabbitMqConfigurator.GetRabbitMqUri()}{RabbitMqConstants.AuditServiceQueueName}");

        var endPoint = await bus.GetSendEndpoint(sendToUri).ConfigureAwait(false);

        await endPoint.Send(logAuditCommand).ConfigureAwait(false);
    }

    /// <summary>
    /// Publish <paramref name="addNotificationCommand"/> command to <see cref="RabbitMqConstants.NotificationServiceQueueName"/> queue.
    /// </summary>
    /// <param name="addNotificationCommand"></param>
    /// <returns></returns>
    public async Task PublishAddNotificationCommandAsync(IAddNotificationCommand addNotificationCommand)
    {
        var bus = _rabbitMqConfigurator.CreateBus();

        var sendToUri = new Uri($"{_rabbitMqConfigurator.GetRabbitMqUri()}{RabbitMqConstants.NotificationServiceQueueName}");

        var endPoint = await bus.GetSendEndpoint(sendToUri).ConfigureAwait(false);

        await endPoint.Send(addNotificationCommand).ConfigureAwait(false);
    }

    /// <summary>
    /// Publish <paramref name="sendPushCommand"/> command to <see cref="RabbitMqConstants.PushServiceQueueName"/> queue.
    /// </summary>
    /// <param name="sendPushCommand"></param>
    /// <returns></returns>
    public async Task PublishSendPushCommandAsync(ISendPushCommand sendPushCommand)
    {
        var bus = _rabbitMqConfigurator.CreateBus();

        var sendToUri = new Uri($"{_rabbitMqConfigurator.GetRabbitMqUri()}{RabbitMqConstants.PushServiceQueueName}");

        var endPoint = await bus.GetSendEndpoint(sendToUri).ConfigureAwait(false);

        await endPoint.Send(sendPushCommand).ConfigureAwait(false);
    }
}
