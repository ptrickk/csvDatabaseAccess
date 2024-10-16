using Autofac;
using CsvAccess.core.Actions.Checkin;
using CsvAccess.core.Actions.Checkout;
using CsvAccess.core.Configuration.Credentials;
using CsvAccess.core.Session;
using CsvAccess.core.Table.Data.Checksum;
using CsvAccess.core.Table.Data.Csv.Convert;

namespace CsvAccess.core.DependencyInjection
{
    public static class ContainerBuilderExtension
    {
        public static void RegisterCoreServices(this ContainerBuilder builder)
        {
            builder.RegisterType<CoreSessionService>().As<SessionService>().SingleInstance();

            builder.RegisterType<CorePathService>().As<PathService>();
            builder.RegisterType<CoreTableCsvService>().As<TableCsvService>();
            builder.RegisterType<CoreChecksumService>().As<ChecksumService>();
            
            builder.RegisterType<CoreCheckinService>().As<CheckinService>();
            builder.RegisterType<CoreCheckoutService>().As<CheckoutService>();
        }
    }
}
