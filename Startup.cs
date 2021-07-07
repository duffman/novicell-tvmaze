//
//   Written by Patrik Forsberg 2021 <patrik.forsberg@coldmind.com>
//   This file is part of the TvMaze Work Sample Project
//

using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Coldmind.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TvMazeWebApp.Core;
using TvMazeWebApp.DataProvider.ColdmindRestIgniter;

namespace TvMazeWebApp
{
	public class Startup
	{
		public readonly AppKernel Kernel = new AppKernel();		

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			var mvcBuilder = services.AddMvc();

			services.AddRazorPages();
			
			services.AddScoped<IColdmindRestClient, ColdmindRestClient>();

			services.AddRazorPages();
			
			var containerBuilder = new ContainerBuilder();
			containerBuilder.Populate(services);

			Kernel.AssignContainerBuilder(containerBuilder);
		}

		public void ConfigureContainer(ContainerBuilder builder)
		{
			ColdmindQLog.Log("Configure Container...");

			// Add WAY-1 (Autofac Module) modules registrations.

			// builder.RegisterModule(new MyAutofacModule());


			// Add WAY-2 (Direct Registration) services registrations.

			//builder.RegisterType<MyService>().As<IService>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

			app.UseRouting();
			app.UseStaticFiles();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Start}/{action=Index}/{id?}");
			});
			
			
			/*
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
			});
			*/
		}
	}
}