using Autofac;
using CsvAccess.core.Actions.Checkout;
using CsvAccess.core.Configuration.Credentials;

namespace CsvAccess.core.DependencyInjection
{
    public static class ContainerBuilderExtension
    {
        public static void RegisterCoreServices(this ContainerBuilder builder)
        {
            builder.RegisterType<CorePathService>().As<PathService>();
            builder.RegisterType<CoreCheckoutService>().As<CheckoutService>();
        }
    }
}
