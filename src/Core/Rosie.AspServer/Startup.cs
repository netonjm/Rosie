﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Rosie.Extensions;
using Rosie.Frontend;
using Rosie.Hue;
using Rosie.Services;
using Rosie.Node;

namespace Rosie.AspServer
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			new HueService(null,null,null);
			NodeService.LinkerPreserve();
			 
			services.AddTransient<IDeviceLogger, SqliteDeviceLogger>();
			services.AddRosie();

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				app.UseHsts();
			}

			//hook custom stuff
			app.UseRosie();
			app.UseRosieFrontend();
		}
	}
}
