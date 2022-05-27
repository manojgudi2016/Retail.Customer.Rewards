using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;


namespace Retail.Customer.Rewards.Api
{
    public class AppSettingsInstance
    {
        private static AppSettingsInstance _appSettings;

        public ConnectionStrings connectionStrings { get; set; }
        public class ConnectionStrings
        {
            public string DefaultDatabase { get; set; }
        }

        public AppSettingsInstance(IConfiguration _connectionString)
        {
            connectionStrings = _connectionString.Get<ConnectionStrings>();
            _appSettings = this;
        }

        public static AppSettingsInstance GetCurrentSettings()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables();

            IConfigurationRoot config = builder.Build();
            var settings = new AppSettingsInstance(config.GetSection("ConnectionStrings"));

            return settings;
        }

    }
}
