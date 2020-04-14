using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CalebsSportsStore.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CalebsSportsStore
{
    public class Startup
    {
        public Startup(IConfiguration confguration) => Configuration = confguration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration["Data:CalebsSportsStoreProducts:ConnectionString1"]));

            services.AddTransient<IProductRepository, EFProductRepository>();

            //services.AddTransient<IProductRepository, FakeProductRepository>();

            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IOrderRepository, EFOrderRepository>();

            services.AddMvc(option => option.EnableEndpointRouting = false);

            //Sets up the In-Memory data store
            services.AddMemoryCache();

            //Registers the services used to access session data
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }

            //Has to be here in order to use style files or any sound, video , photo pushed to user
            app.UseStaticFiles();

            //Allows the session system to automatically associate requests
            //with sessions when they arrive from the client
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: null,
                    template: "{category}/Page{productPage:int}",
                    defaults: new { controller = "Product", action = "List" }
                );

                routes.MapRoute(
                    name: null,
                    template: "Page{productPage:int}",
                    defaults: new { controller = "Product", action = "List", productPage = 1 }
                );

                routes.MapRoute(
                name: null,
                template: "{category}", defaults: new { controller = "Product", action = "List", productPage = 1 }
                );

                routes.MapRoute(
                name: null,
                template: "",
                defaults: new { controller = "Product", action = "List", productPage = 1 }
                );

                //Normal Default Route
                //routes.MapRoute(name: "default", template: "{controller=home}/{action=Index}/{id?}");
                //routes.MapRoute("default", "{controller=home}/{action=Index}/{id?}");

                routes.MapRoute(name: null, template: "{controller}/{action}/{id?}");

                //Final from FROM CH. 8
                //routes.MapRoute(
                //    name: "pagination",
                //    template: "Products/Page{productPage}",
                //    defaults: new { Controller = "Product", action = "List" });

                //routes.MapRoute(
                //    name: "default",
                //    template: "{controller=Product}/{action=List}/{id?}");
            });
            SeedData.EnsurePopulated(app);

            //app.UseRouting();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
    }
}
