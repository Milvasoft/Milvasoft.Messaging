using System.Collections.Generic;

namespace Milvasoft.Messaging.RabbitMq.Commands;

/// <summary>
/// Command to send a push notification. The consumer delivers it to the given device <see cref="Tokens"/>
/// via FCM. Device-token resolution is done by the producer, so the push consumer stays storage-agnostic
/// (no database access) and reusable across projects.
/// </summary>
public interface ISendPushCommand
{
    /// <summary>
    /// Sender application.
    /// </summary>
    public string Application { get; set; }

    /// <summary>
    /// Target device (FCM) tokens.
    /// </summary>
    public List<string> Tokens { get; set; }

    /// <summary>
    /// Notification title.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Notification body.
    /// </summary>
    public string Body { get; set; }

    /// <summary>
    /// Arbitrary data payload delivered alongside the notification (FCM data message).
    /// </summary>
    public Dictionary<string, string> Data { get; set; }
}

/// <summary>
/// Command to send a push notification.
/// </summary>
public class SendPushCommand : ISendPushCommand
{
    /// <summary>
    /// Sender application.
    /// </summary>
    public string Application { get; set; }

    /// <summary>
    /// Target device (FCM) tokens.
    /// </summary>
    public List<string> Tokens { get; set; } = [];

    /// <summary>
    /// Notification title.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Notification body.
    /// </summary>
    public string Body { get; set; }

    /// <summary>
    /// Arbitrary data payload delivered alongside the notification (FCM data message).
    /// </summary>
    public Dictionary<string, string> Data { get; set; } = [];
}
