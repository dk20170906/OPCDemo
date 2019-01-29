using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OPCDemom
{
    public class JsonConfigurationHelper
    {
        public T GetAppSettings<T>(string key) where T : class, new()
        {
            var baseDir = AppContext.BaseDirectory;
            var indexSrc = baseDir.IndexOf("src");
            var subToSrc = baseDir.Substring(0, indexSrc);
            var currentClassDir = subToSrc + "src" + Path.DirectorySeparatorChar + "OPCDemom";




            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(currentClassDir)
                 .AddJsonFile("appsettings.json", false, true)
                .Build();
            var appconfig = new ServiceCollection()
                .AddOptions()
                .Configure<T>(config.GetSection(key))
                .BuildServiceProvider()
                .GetService<IOptions<T>>()
                .Value;
            return appconfig;
        }
    }
}
