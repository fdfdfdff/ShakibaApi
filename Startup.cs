using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using RCNClinicApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace RCNClinicApp.MobileAppService
{
    //public class Startup
    //{
    //    public Startup(IConfiguration configuration)
    //    {
    //        Configuration = configuration;
    //    }

    //    public IConfiguration Configuration { get; }

    //    // This method gets called by the runtime. Use this method to add services to the container.
    //    public void ConfigureServices(IServiceCollection services)
    //    {

    //        services.Configure<CookiePolicyOptions>(options =>
    //        {

    //           // options.CheckConsentNeeded = context => true;
    //            options.MinimumSameSitePolicy = SameSiteMode.None;
    //        });

    //        services.AddDbContext<ContextDb>(db => db.UseSqlServer(Configuration.GetConnectionString("ContextDb")));
    //        //services.AddDefaultIdentity<IdentityUser>()
    //        //   .AddDefaultUI(UIFramework.Bootstrap4)
    //        //       .AddEntityFrameworkStores<ContextDb>();

    //        // services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    //        services.AddScoped(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
    //        //services.AddScoped(typeof(IRepository<>), typeof(RepositoryContext< , >));

    //        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


    //        //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
    //        //services.AddSingleton<IItemRepository, ItemRepository>();

    //        services.AddSwaggerGen(c =>
    //        {
    //            c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
    //        });
    //    }

    //    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    //    {
    //        if (env.IsDevelopment())
    //        {
    //            app.UseDeveloperExceptionPage();
    //            app.UseDatabaseErrorPage();
    //        }
    //        else
    //        {
    //            app.UseExceptionHandler("/Home/Error");
    //            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //            //app.UseHsts();
    //        }

    //        //app.UseHttpsRedirection();
    //        app.UseStaticFiles();
    //        app.UseCookiePolicy();
    //        //app.UseAuthentication();
    //        app.UseMvc(routes =>
    //        {
    //            routes.MapRoute(
    //                name: "default",
    //                template: "{controller=Home}/{action=Index}/{id?}");
    //        });

    //        app.UseSwagger();
    //        app.UseSwaggerUI(c =>
    //        {
    //            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    //        });
    //    }
    //}
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region me
            //services.Configure<CookiePolicyOptions>(options =>
            //{

            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});

            services.AddDbContext<ContextDb>(db => db.UseSqlServer(Configuration.GetConnectionString("ContextDb")));
            //services.AddDefaultIdentity<IdentityUser>()
            //   .AddDefaultUI(UIFramework.Bootstrap4)
            //       .AddEntityFrameworkStores<ContextDb>();

            // services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
            //services.AddScoped(typeof(IRepository<>), typeof(RepositoryContext< , >));

            #endregion

            services.AddMvc();
          
            services.AddSingleton<IItemRepository, ItemRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.Run(async (context) => await Task.Run(() => context.Response.Redirect("/swagger")));
        }
    }
}
