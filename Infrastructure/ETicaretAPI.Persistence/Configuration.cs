using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence
{
    internal static class Configuration
    {
        public static string ConnectionString 
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/ETicaretAPI.WebAPI"));
                configurationManager.AddJsonFile("appsettings.json");

                return configurationManager.GetConnectionString("PostgreSQL");
            } 
             
        }
    }
}

// Not1: appsettings.json dosyasında connectionString e erişebilmek ve her defasında aynı kodları yazmamak için Static bir Configuration classı oluşturduk ve içerisinde bize connectionString dönen bir property yazdık.

// Not2: ConfigurationManager'ı kullanabilmek için NuGet üzerinden Persistence katmanına Microsoft.Extensions.Configuration paketini kurmamız gerekiyor.

// Not3: AddJsonFile extension a ulaşabilmek için yine NuGet üzerinden Microsoft.Extensions.Configuration.Json paketini kurmamız gerekmektedir.

// Not4: IoC ye register ederek DbContext yapımızı her dahafında yazmamak için ServiceRegistration üzerinde DbContext olarak ekledik ve paramtre olarak yukarıdaki metotu verdik.