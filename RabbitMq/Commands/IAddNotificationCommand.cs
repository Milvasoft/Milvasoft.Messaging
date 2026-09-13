using System.Collections.Generic;

namespace Milvasoft.Messaging.RabbitMq.Commands;

/// <summary>
/// Command to insert an in-app (internal) notification row. Kept generic like <see cref="ILogAuditCommand"/>
/// so any project can push in-app notifications into its own database/table over the shared bus: the
/// consumer inserts <see cref="Data"/> into <see cref="TableName"/> using <see cref="ConnectionString"/>.
/// </summary>
public interface IAddNotificationCommand
{
    /// <summary>
    /// Notification row data as column name → value (e.g. RecipientUserName, Type, Text, Data, ...).
    /// </summary>
    public Dictionary<string, object> Data { get; set; }

    /// <summary>
    /// Connection string of the database the notification row is inserted into.
    /// </summary>
    public string ConnectionString { get; set; }

    /// <summary>
    /// Target table name for the notification row.
    /// </summary>
    public string TableName { get; set; }

    /// <summary>
    /// Sender application.
    /// </summary>
    public string Application { get; set; }
}

/// <summary>
/// Command to insert an in-app (internal) notification row.
/// </summary>
public class AddNotificationCommand : IAddNotificationCommand
{
    /// <summary>
    /// Notification row data as column name → value (e.g. RecipientUserName, Type, Text, Data, ...).
    /// </summary>
    public Dictionary<string, object> Data { get; set; } = [];

    /// <summary>
    /// Connection string of the database the notification row is inserted into.
    /// </summary>
    public string ConnectionString { get; set; }

    /// <summary>
    /// Target table name for the notification row.
    /// </summary>
    public string TableName { get; set; }

    /// <summary>
    /// Sender application.
    /// </summary>
    public string Application { get; set; }
}
