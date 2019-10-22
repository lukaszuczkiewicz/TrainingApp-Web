using PlainCQRS.Core.Events;
using Notification;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System.Text;
using Application.Coach.Events;

namespace Application.Notification
{
    public class TrainingCreatedEventHandler : IEventHandler<TrainingCreated>
    {
        IOptions<RabitMqSendConfiguration> rabitMqConfiguration;

        public TrainingCreatedEventHandler(IOptions<RabitMqSendConfiguration> configuration)
        {
            this.rabitMqConfiguration = configuration;
        }

        public void Handle(TrainingCreated @event)
        {
            var factory = new ConnectionFactory()
            {
                HostName = rabitMqConfiguration.Value.HostName
            };

            using (var connection = factory.CreateConnection())
            {
                using (var model = connection.CreateModel())
                {
                    model.QueueDeclare(
                        queue: rabitMqConfiguration.Value.QueueName,
                        durable: rabitMqConfiguration.Value.Durable,
                        exclusive: rabitMqConfiguration.Value.Exclusive,
                        autoDelete: rabitMqConfiguration.Value.AutoDelete,
                        arguments: null
                        );

                    var msgBody = Encoding.UTF8.GetBytes(@event.CoachName);

                    model.BasicPublish(
                        exchange: "",
                        routingKey: "",
                        body: msgBody);
                }
            }

        }
    }
}
