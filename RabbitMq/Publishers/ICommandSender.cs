using Milvasoft.Messaging.RabbitMq.Commands;
using System.Threading.Tasks;

namespace Milvasoft.Messaging.RabbitMq.Publishers
{
    public interface ICommandSender
    {
        Task PublishSendMailCommandAsync(ISendMailCommand sendMailCommand);
    }
}
