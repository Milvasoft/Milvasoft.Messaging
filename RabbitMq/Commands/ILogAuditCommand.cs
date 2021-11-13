using System;

namespace Milvasoft.Messaging.RabbitMq.Commands;

/// <summary>
/// User activity log. Which is Add-Update-Delete process.
/// </summary>
public interface ILogAuditCommand
{
    /// <summary>
    /// Id of log.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// UserName of the user who performed the activity
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// User performed activity.
    /// </summary>
    public string Activity { get; set; }

    /// <summary>
    /// Activity performer ip address.
    /// </summary>
    public string Ip { get; set; }

    /// <summary>
    /// Creation date of entity.
    /// </summary>
    public DateTime CreationDate { get; set; }

    /// <summary>
    /// Connection string for inserting log to database.
    /// </summary>
    public string ConnectionString { get; set; }

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
    /// Id of log.
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// UserName of the user who performed the activity
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// User performed activity.
    /// </summary>
    public string Activity { get; set; }

    /// <summary>
    /// Activity performer ip address.
    /// </summary>
    public string Ip { get; set; }

    /// <summary>
    /// Creation date of entity.
    /// </summary>
    public virtual DateTime CreationDate { get; set; }

    /// <summary>
    /// Connection string for inserting log to database.
    /// </summary>
    public string ConnectionString { get; set; }

    /// <summary>
    /// Sender application.
    /// </summary>
    public string Application { get; set; }
}
