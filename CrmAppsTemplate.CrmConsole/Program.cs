using CrmAppsTemplate.CrmConnectionPrvdr;
using CrmAppsTemplate.CrmDataPrvdr;
using CrmAppsTemplate.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CrmAppsTemplate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var host = CreateHost();
            var crmConnectionProvider = ActivatorUtilities.CreateInstance<CrmConnectionProvider>(host.Services);
        }

        private static IHost CreateHost() =>
            Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                var ccs = context.Configuration.GetSection("CrmConnection").Get<CrmConnectionOptions>();
                services.AddOptions<CrmConnectionOptions>();
                //services.Configure<CrmConnectionOptions>(context.Configuration.GetSection("CrmConnection"));
                services.AddSingleton<CrmConnectionProvider>();
                services.AddSingleton<CrmDataProvider>();
            })
            .Build();
    }
}