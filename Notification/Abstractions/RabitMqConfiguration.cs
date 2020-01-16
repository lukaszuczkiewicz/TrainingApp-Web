namespace Notification
{
    public class RabitMqSendConfiguration
    {
        public string HostName { get; set; }
        public string QueueName { get; set; }
        public bool Durable { get; set; }
        public bool Exclusive { get; set; }
        public bool AutoDelete { get; set; }

    }
}
