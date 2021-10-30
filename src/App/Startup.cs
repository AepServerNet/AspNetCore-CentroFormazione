using System;
using System.Globalization;
using System.IO;
using App.Customizations.ModelBinders;
using App.Models.Options;
using App.Models.Services.Application;
using App.Models.Services.Application.Docenti;
using App.Models.Services.Application.Edifici;
using App.Models.Services.Infrastructure;
using App.Models.Validators;
using App.Models.Validators.Docente;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => 
            {
                options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
            })
            .AddFluentValidation(options => {
                options.RegisterValidatorsFromAssemblyContaining<DocenteCreateValidator>();
                options.ConfigureClientsideValidation(clientSide =>
                {
                    clientSide.Add(typeof(IRemotePropertyValidator), (context, description, validator) => new RemoteClientValidator(description, validator));
                });
            });

            //Database
            services.AddDbContextPool<FormazioneDbContext>(optionsBuilder => {
                string connectionString = Configuration.GetSection("ConnectionStrings").GetValue<string>("Default");
                optionsBuilder.UseSqlServer(connectionString, options => 
                {
                    options.EnableRetryOnFailure(3);
                });
            });

            services.AddSingleton<IErrorViewSelectorService, ErrorViewSelectorService>();
            services.AddTransient<IDocentiService, EfCoreDocentiService>();
            services.AddTransient<IEdificiService, EfCoreEdificiService>();
            
            //Options
            services.Configure<DocenteOptions>(Configuration.GetSection("Docente"));
            services.Configure<EdificioOptions>(Configuration.GetSection("Edificio"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime lifetime)
        {
            if (env.IsEnvironment("Development"))
            {
                app.UseDeveloperExceptionPage();

                lifetime.ApplicationStarted.Register(() =>
                {
                    string filePath = Path.Combine(env.ContentRootPath, "bin/reload.txt");
                    File.WriteAllText(filePath, DateTime.Now.ToString());
                });
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            CultureInfo appCulture = new("it-IT");

            app.UseStaticFiles();
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(appCulture),
                SupportedCultures = new[] { appCulture }
            });

            app.UseRouting();
            app.UseEndpoints(routeBuilder => {
                routeBuilder.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                routeBuilder.MapFallbackToController("{*path}", "Index", "Error");
            });
        }
    }
}