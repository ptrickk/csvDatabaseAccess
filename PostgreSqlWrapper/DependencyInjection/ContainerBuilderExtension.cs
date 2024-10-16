using Autofac;
using CsvAccess.core.Configuration;
using CsvAccess.core.Credentials;
using CsvAccess.core.Models.Persistence;
using CsvAccess.core.Table.Columns.Get.ByTable;
using CsvAccess.core.Table.Data;
using PostgreSqlWrapper.Connection;
using PostgreSqlWrapper.Table.Columns;
using PostgreSqlWrapper.Table.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgreSqlWrapper.DependencyInjection
{
    public static class ContainerBuilderExtension
    {
        public static void RegisterPostgresServices(this ContainerBuilder builder)
        {
            builder.RegisterType<PostgresConnectionService>().As<ConnectionService>();
            builder.RegisterType<PostgresCredentialsService>().As<CredentialsService>();
            builder.RegisterType<PostgresDataColumnService>().As<DataColumnService>();
            builder.RegisterType<PostgresDataTableService>().As<DataTableService>();
        }
    }
}
