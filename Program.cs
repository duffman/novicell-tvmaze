using Autofac.Extensions.DependencyInjection;
using Coldmind.Utils;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace TvMazeWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            ColdmindQLog.Log("CreateHostBuilder", args);
            return Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }
    }
}
