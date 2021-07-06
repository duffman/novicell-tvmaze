using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TheMaze.Containers;
using TheMaze.Core;
using TheMaze.Database;
using TheMaze.Utils.Logging;

namespace TheMaze
{
    class Program
    {
        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {
            RichLog.WriteWarning("The Maze - Work Sample by Patrik Forsberg 2021");
            var builder = new ContainerBuilder();
            builder.RegisterType<DBManager>().As<ISQLiteDB>();
            builder.RegisterType<RESTConsumer>().As<IRESTConsumer>();

            Console.ReadLine();
        }
    }

    /*
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    */
}
