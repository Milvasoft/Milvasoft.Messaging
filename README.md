## Provides models and configurations for message broker and service bus operations. With [MassTransit](https://github.com/MassTransit/MassTransit)
  
[![license](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/Milvasoft/Milvasoft/blob/master/LICENSE)  [![NuGet](https://img.shields.io/nuget/v/Milvasoft.Templates.Web.Ef)](https://www.nuget.org/packages/Milvasoft.Helpers/)   [![NuGet](https://img.shields.io/nuget/dt/Milvasoft.Messaging)](https://www.nuget.org/packages/Milvasoft.Messaging) 

# Requirements
One of the runtime environment is required from below
* .NET 5.0
* RabbitMQ

# Installation

For now you'll need to install following libraries:

* To install Milvasoft.Messaging, run the following command in the Package Manager Console
```
Install-Package Milvasoft.Messaging
```
 Or you can download the latest .dll from [Github](https://github.com/Milvasoft/Milvasoft.Messaging)

Before using this library install RabbitMQ to your machine. You can run RabbitMQ easily with [Docker](https://hub.docker.com/_/rabbitmq).

# Milvasoft.Messaging Usage

In Startup.cs;

```csharp 1

...
	    
 services.AddMilvaMessaging(cfg =>
 {
     cfg.RabbitMqUri = "rabbitmq://localhost:5672/";
     cfg.UserName = "admin";
     cfg.Password = "yourstrongpassword";
 });

...

```

For send mail command to RabbitMQ, you can use ready made publisher;

```csharp 1

...
	    
await _lazyCommandSender.Value.PublishSendMailCommandAsync(new SendMailCommand
{
    From = "sender@yourdomain.com",
    FromPassword = "yourstrongpassword",
    Port = 587,
    SmtpHost = "mail.yourdomain.com",
    To = "reciever@somedomain.com",
    Subject = "Test Mail",
    HtmlBody = htmlContent
});

...

```

Or you can publish command manually.

For recieve and process send mail, you must write consumer project. This can be console application, web api or etc.

We will create console application for this tutorial.

The console project you have created needs to be constantly up, so that it listens to the RabbitMQ queue and performs the operation when a new command arrives. For this, your main method can be as follows;

In Program.cs;

```csharp 1

static async Task Main(string[] args)
{
    Console.Title = "Milvasoft.MailSenderMicroService";

    var builder = new HostBuilder().ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<MailHostedService>();

        var busConfigurator = new RabbitMqBusConfigurator(new RabbitMqConfiguration
        {
            RabbitMqUri = "rabbitmq://localhost:5672/",
            UserName = "admin",
            Password = "yourstrongpassword",
        });

        var bus = busConfigurator.CreateBus(cfg =>
        {            
            cfg.ReceiveEndpoint(RabbitMqConstants.MailServiceQueueName, e =>
            {
                e.Consumer<SendMailCommandConsumer>();
                
                //You can configure your recieve endpoint according to your needs in MassTransit.
                e.UseMessageRetry(r => r.Interval(2, 30000));
                e.UseRateLimit(30, TimeSpan.FromMinutes(1));
            });
        });

        services.AddSingleton(bus);
    });

    await builder.RunConsoleAsync();
}

```

Create new class which named MailHostedService. This will provide your console app is constantly up.

```csharp 1

using MassTransit;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Milvasoft.Consumers.Mails
{
    public class MailHostedService : IHostedService
    {
        private readonly IBusControl _bus;

        /// <summary>
        /// Initializes new instance of <see cref="MailHostedService"/>.
        /// </summary>
        /// <param name="bus"></param>
        public MailHostedService(IBusControl bus)
        {
            _bus = bus;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await Console.Out.WriteLineAsync("Listening for Email Service commands/events...");

            await _bus.StartAsync(cancellationToken).ConfigureAwait(false);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Email Service stopping.");

            return _bus.StopAsync(cancellationToken);
        }
    }
}

```

Create class which named SendMailCommandConsumer. This class will listen to the queue and run the incoming commands. 


```csharp 1

using MassTransit;
using Milvasoft.Messaging.RabbitMq.Commands;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Milvasoft.Consumers.Mails
{
    public class SendMailCommandConsumer : IConsumer<ISendMailCommand>
    {
        public async Task Consume(ConsumeContext<ISendMailCommand> context)
        {
            try
            {
                using var mailMessage = new MailMessage(context.Message.From,
                                                        context.Message.To,
                                                        context.Message.Subject,
                                                        context.Message.HtmlBody)
                {
                    IsBodyHtml = true
                };

                using var smtpClient = new SmtpClient(context.Message.SmtpHost, context.Message.Port);

                smtpClient.Credentials = new NetworkCredential(context.Message.From, context.Message.FromPassword);

                await smtpClient.SendMailAsync(mailMessage).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync("An error occured when sending mail.");
            }
        }
    }
}

```

In this way, you can perform operations independent of your project with RabbitMQ. The main purpose of the library is to combine the models that need to be shared between the publisher and the consumer and to provide an abstraction for doing these operations. 

### You can contribute to the development of this library by adding more various operations.
