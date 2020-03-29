using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BlazorApp.Data;
using System.Net.Http;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using BlazorStrap;
using Microsoft.AspNetCore.Http;

namespace BlazorApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor().AddCircuitOptions(o => o.DetailedErrors = true);
            services.AddBootstrapCss();
            services.AddSingleton<WeatherForecastService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Server Side Blazor doesn't register HttpClient by default
            if (!services.Any(x => x.ServiceType == typeof(HttpClient)))
            {
                // Setup HttpClient for server side in a client side compatible fashion
                services.AddScoped<HttpClient>(s =>
                {
                    // Creating the URI helper needs to wait until the JS Runtime is initialized, so defer it.      
                    var uriHelper = s.GetRequiredService<NavigationManager>();
                    return new HttpClient
                    {
                        BaseAddress = new Uri(uriHelper.BaseUri)
                    };
                });
            }

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
               .AddCookie("Cookies")
               .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
               {
                   options.Authority = "https://demo.identityserver.io/";
                   options.ClientId = "server.hybrid.short";
                   options.ClientSecret = "secret";
                   options.ResponseType = "code id_token";
                   options.Scope.Add("openid");
                   options.Scope.Add("profile");
                   options.Scope.Add("email");
                   options.Scope.Add("api");
                   options.CallbackPath = "/signin-oidc";
                   options.SaveTokens = true;
                   options.GetClaimsFromUserInfoEndpoint = true;

                   options.Events = new OpenIdConnectEvents
                   {
                       OnAccessDenied = context =>
                       {
                           context.HandleResponse();
                           context.Response.Redirect("/");
                           return Task.CompletedTask;
                       }
                   };
               });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
