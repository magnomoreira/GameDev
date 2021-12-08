using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using DevGames.Api.Mappers;
using DevGames.Api.Persistence;
using DevGames.Api.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevGames.Api
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
			services.AddAutoMapper(typeof(BoardMappers));
			services.AddDbContext<DevGamesContext>(o => o.UseSqlServer(Configuration.GetConnectionString(name: "DevGamesCs")));
			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "DevGames.Api", Version = "v1" ,
					Contact = new OpenApiContact
					{
						Name = "Magno Moreira",
						Email = "magnomoreira@yahoo.com",
						Url = new  Uri("magnoDev.com.br")
					}
				});
			});
			services.AddScoped<IBoardRepository, BoardRepository>();
			services.AddScoped<IPostRepository, PostRepository>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DevGames.Api v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
