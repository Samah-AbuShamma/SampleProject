using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace TrainingProject
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

			// In production, the Angular files will be served from this directory
			services.AddSpaStaticFiles(configuration =>
			{
				configuration.RootPath = "ClientApp/dist";
			});

			services.AddAutoMapper(options =>
			{
				options.ForAllMaps((type, ex) =>
				{
					ex.ValidateMemberList(MemberList.None);
				});
			}, AppDomain.CurrentDomain.GetAssemblies());

			services.AddCors(options =>
			{
				options.AddPolicy("CorsPolicy",
					builder => builder
					.WithOrigins(Configuration.GetSection("SystemConfig").GetValue<string>("BaseUiUrl"))
					.AllowAnyMethod()
					.AllowAnyHeader()
					.AllowCredentials());
			});

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{

			app.UseHttpsRedirection();
			app.UseCors("CorsPolicy");
			app.UseStaticFiles();
			app.UseSpaStaticFiles();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller}/{action=Index}/{id?}");
			});

		}
	}
}
