//
//   Written by Patrik Forsberg 2021 <patrik.forsberg@coldmind.com>
//   This file is part of the TvMaze Work Sample Project
//

using System;
using Autofac;
using Coldmind.Utils;
using Microsoft.EntityFrameworkCore;
using TvMazeWebApp.DataProvider.ColdmindRestIgniter;
using TvMazeWebApp.DataProvider.Types;

namespace TvMazeWebApp.Core
{
    public class AppKernel
    {
        public static IContainer Container { get; internal set; }

        public AppKernel() { }

        public IServiceProvider AssignContainerBuilder(ContainerBuilder builder)
        {
            ColdmindQLog.Log("AssignContainerBuilder");


            using (var dbContext = new DbContext())
            {
                dbContext.Database.EnsureCreated();
                if (!dbContext..Any())
                {
                    dbContext.Blogs.AddRange(new Blog[]
                    {
                        new CastMember{ new Person{ Id = 10, Name = "Kalle Kula"} },
                        new CastMember{ new Person{ Id = 10, Name = "Snuffe Kanot"} },
                        new CastMember{ new Person{ Id = 10, Name = "Buffe Bula"} }
                    });
                    dbContext.SaveChanges();
                }
                foreach (var blog in dbContext.Blogs)
                {
                    Console.WriteLine($"BlogID={blog.BlogId}\tTitle={blog.Title}\t{blog.SubTitle}\tDateTimeAdd={blog.DateTimeAdd}");
                }
            }            
            
            
            builder.RegisterType<ColdmindRestClient>().As<IColdmindRestClient>();


            
            Container = builder.Build();
            return Container.Resolve<IServiceProvider>();
        }
        
        
    }
}

