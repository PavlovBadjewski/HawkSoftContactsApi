using HawkSoftContactsApi.Models;
using HawkSoftContactsApi.Handlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HawkSoftContactsApi.Repositories;

namespace HawkSoftContactsApi
{
    public class Startup
    {
        private string _corsPolicy = "test-cors-policy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: _corsPolicy,
                                  builder =>
                                  {
                                    builder.WithOrigins("http://localhost:3000")
                                    .AllowAnyHeader()
                                    .AllowAnyMethod();
                                  });
            });

            services.AddScoped<IUserContactHandler, UserContactHandler>();
            services.AddScoped<IUserContactRepository, UserContactRepository>();
            services.AddScoped<UserContactsContext, UserContactsContext>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(_corsPolicy);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers()
                    .RequireCors(_corsPolicy);
            });
        }
    }
}
