using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using FreeSmokyMarket.Data.Repositories;
using FreeSmokyMarket.EF.Repositories;
using FreeSmokyMarket.EF;
using FreeSmokyMarket.Infrastructure.NotificationSenders;
using FreeSmokyMarket.Infrastructure.Interfaces;
using FreeSmokyMarket.Domain.Interfaces;
using FreeSmokyMarket.Domain.Services;

namespace FreeSmokyMarket
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddDbContext<FreeSmokyMarketContext>();
            services.AddTransient<ISenderFactory, SenderFactory>();
            services.AddTransient<IBasketRepository, BasketRepository>();
            services.AddTransient<IReservationService, ReservationService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.Name = ".MyApp.Session";
                options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                options.IdleTimeout = TimeSpan.FromMinutes(ReservationService.SessionTimeLimitInMinutes);
            });

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory f)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            
            app.UseStaticFiles();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=MainPage}/{id?}");
            });
        }
    }
}