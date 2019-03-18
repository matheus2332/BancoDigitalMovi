using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace GerarArquivo
{
    public static class ConnectionString
    {
        public static string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            return configuration.GetConnectionString("DefaultConnection");
        }
    }
}