using System.Collections.Generic;

namespace Milvasoft.Messaging.RabbitMq.Commands;

/// <summary>
/// Command to update or end iOS Live Activities through FCM (<c>apns.live_activity_token</c>). The consumer sends one APNs
/// Live Activity push per <see cref="Targets"/> entry with the same <see cref="ContentState"/>. The producer resolves the
/// targets and builds the content state, so the push consumer stays storage-agnostic and app-agnostic: it never reads
/// the content state, it only passes it on as the payload's <c>content-state</c>.
/// </summary>
public interface ISendLiveActivityCommand
{
    /// <summary>
    /// Name of the Firebase profile configured on the push service (<c>Fcm:Profiles</c>). Empty or unknown falls back to
    /// the service's default profile.
    /// </summary>
    public string ConfigurationKey { get; set; }

    /// <summary>
    /// Sender application.
    /// </summary>
    public string Application { get; set; }

    /// <summary>
    /// The activities to push to: each one's device (FCM) token and its Live Activity push token.
    /// </summary>
    public List<LiveActivityTarget> Targets { get; set; }

    /// <summary>
    /// <c>update</c> or <c>end</c> (APNs <c>aps.event</c>).
    /// </summary>
    public string Event { get; set; }

    /// <summary>
    /// The activity's new content state as a JSON object (APNs <c>aps.content-state</c>), in the shape the app's activity
    /// decodes.
    /// </summary>
    public string ContentState { get; set; }

    /// <summary>
    /// When the state was produced, in Unix seconds (APNs <c>aps.timestamp</c>). The system drops a push older than the
    /// state it already shows.
    /// </summary>
    public long Timestamp { get; set; }

    /// <summary>
    /// For <c>end</c>: when the system removes the ended activity from the Lock Screen, in Unix seconds (APNs
    /// <c>aps.dismissal-date</c>). Null leaves it to the system (up to four hours); a past time removes it at once.
    /// </summary>
    public long? DismissalDate { get; set; }

    /// <summary>
    /// APNs priority: 10 delivers at once, 5 lets the system pick the time (it limits the number of 10s).
    /// </summary>
    public int Priority { get; set; }
}

/// <summary>
/// Command to update or end iOS Live Activities through FCM.
/// </summary>
public class SendLiveActivityCommand : ISendLiveActivityCommand
{
    /// <summary>
    /// Name of the Firebase profile configured on the push service (<c>Fcm:Profiles</c>). Empty or unknown falls back to
    /// the service's default profile.
    /// </summary>
    public string ConfigurationKey { get; set; }

    /// <summary>
    /// Sender application.
    /// </summary>
    public string Application { get; set; }

    /// <summary>
    /// The activities to push to: each one's device (FCM) token and its Live Activity push token.
    /// </summary>
    public List<LiveActivityTarget> Targets { get; set; } = [];

    /// <summary>
    /// <c>update</c> or <c>end</c> (APNs <c>aps.event</c>).
    /// </summary>
    public string Event { get; set; }

    /// <summary>
    /// The activity's new content state as a JSON object (APNs <c>aps.content-state</c>), in the shape the app's activity
    /// decodes.
    /// </summary>
    public string ContentState { get; set; }

    /// <summary>
    /// When the state was produced, in Unix seconds (APNs <c>aps.timestamp</c>).
    /// </summary>
    public long Timestamp { get; set; }

    /// <summary>
    /// For <c>end</c>: when the system removes the ended activity from the Lock Screen, in Unix seconds.
    /// </summary>
    public long? DismissalDate { get; set; }

    /// <summary>
    /// APNs priority: 10 delivers at once, 5 lets the system pick the time.
    /// </summary>
    public int Priority { get; set; } = 10;
}

/// <summary>
/// One Live Activity to push to.
/// </summary>
public class LiveActivityTarget
{
    /// <summary>
    /// FCM registration token of the device the activity runs on (FCM addresses the app with it).
    /// </summary>
    public string DeviceToken { get; set; }

    /// <summary>
    /// The activity's own APNs push token (ActivityKit <c>pushToken</c>).
    /// </summary>
    public string ActivityToken { get; set; }
}
