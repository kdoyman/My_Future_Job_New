using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerApi.Interface;
using CustomerApi.Services;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CustomerApi
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
            services.AddControllers();
            services.Configure<CustomerDbSettings>(Configuration.GetSection(nameof(CustomerDbSettings)));
            services.AddSingleton<ICustomerDbSettings>(sp => sp.GetRequiredService<IOptions<CustomerDbSettings>>().Value);
            services.AddSingleton<CustomerService>();

            services.AddScoped<ICustomerService, CustomerService>();

            services.AddCors(o => o.AddPolicy("Open", builder =>
            { builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader(); 
            }));

            var requireAuthenticatedUsersPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            services.AddControllers(conf => { conf.Filters.Add(new AuthorizeFilter(requireAuthenticatedUsersPolicy)); });

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
               .AddIdentityServerAuthentication(options =>
               {
                   // base-address of your identityserver
                   options.Authority = "https://demo.identityserver.io";

                   // name of the API resource
                   options.ApiName = "api";
                   options.ApiSecret = "secret";

                   options.EnableCaching = true;
                   options.CacheDuration = TimeSpan.FromMinutes(180); // that's not the default
               });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("Open");
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
