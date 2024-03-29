﻿using Milvasoft.Messaging.RabbitMq.Commands;
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
}
