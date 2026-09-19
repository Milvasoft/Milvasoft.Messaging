using System.Collections.Generic;

namespace Milvasoft.Messaging.RabbitMq.Commands;

/// <summary>
/// Command to remove device tokens that Firebase no longer accepts (the app was uninstalled or the token expired).
/// The push service sends it after a delivery, since it only receives token lists and has no storage; the app that
/// owns the tokens drains the <see cref="RabbitMqConstants.GetRemovePushTokensQueueName(string)"/> queue of its
/// <see cref="ConfigurationKey"/> and deletes them.
/// </summary>
public interface IRemovePushTokensCommand
{
    /// <summary>
    /// Configuration key the rejected push was sent with (<see cref="ISendPushCommand.ConfigurationKey"/>, as the producer
    /// set it). It picks the queue, so the producer drains the queue of the same key it pushes with.
    /// </summary>
    public string ConfigurationKey { get; set; }

    /// <summary>
    /// Application whose push was rejected.
    /// </summary>
    public string Application { get; set; }

    /// <summary>
    /// Device (FCM) tokens to remove.
    /// </summary>
    public List<string> Tokens { get; set; }
}

/// <summary>
/// Command to remove device tokens that Firebase no longer accepts.
/// </summary>
public class RemovePushTokensCommand : IRemovePushTokensCommand
{
    /// <summary>
    /// Configuration key the rejected push was sent with (<see cref="ISendPushCommand.ConfigurationKey"/>, as the producer
    /// set it). It picks the queue, so the producer drains the queue of the same key it pushes with.
    /// </summary>
    public string ConfigurationKey { get; set; }

    /// <summary>
    /// Application whose push was rejected.
    /// </summary>
    public string Application { get; set; }

    /// <summary>
    /// Device (FCM) tokens to remove.
    /// </summary>
    public List<string> Tokens { get; set; } = [];
}
