using Autofac;
using Notification.Email;

namespace Api.CompositionRoot
{
    public class NotificationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterDI(builder);
        }

        private void RegisterDI(ContainerBuilder builder)
        {
            builder.RegisterType<EmailSender>()
                .As<IEmailSender>()
                .InstancePerLifetimeScope();
        }
    }
}
