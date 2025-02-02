using System.Collections.Generic;

namespace Milvasoft.Messaging.RabbitMq.Commands;

/// <summary>
/// User activity log. Which is Add-Update-Delete process.
/// </summary>
public interface ILogAuditCommand
{
    /// <summary>
    /// Log data
    /// </summary>
    public Dictionary<string, object> Data { get; set; }

    /// <summary>
    /// Connection string for inserting log to database.
    /// </summary>
    public string ConnectionString { get; set; }

    /// <summary>
    /// Log table name.
    /// </summary>
    public string TableName { get; set; }

    /// <summary>
    /// Sender application.
    /// </summary>
    public string Application { get; set; }
}

/// <summary>
/// User activity log. Which is Add-Update-Delete process.
/// </summary>
public class LogAuditCommand : ILogAuditCommand
{
    /// <summary>
    /// Log data
    /// </summary>
    public Dictionary<string, object> Data { get; set; } = [];

    /// <summary>
    /// Connection string for inserting log to database.
    /// </summary>
    public string ConnectionString { get; set; }

    /// <summary>
    /// Log table name.
    /// </summary>
    public string TableName { get; set; }

    /// <summary>
    /// Sender application.
    /// </summary>
    public string Application { get; set; }
}