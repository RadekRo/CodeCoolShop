using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Codecool.CodecoolShop
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
            services.AddControllersWithViews();
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.Name = ".Codecool.Session";
                options.IdleTimeout = TimeSpan.FromMinutes(30);
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
                app.UseExceptionHandler("/Product/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Product}/{action=Index}/{id?}");
            });

            app.UseSession();
            SetupInMemoryDatabases();
        }

        private void SetupInMemoryDatabases()
        {
            IProductDao productDataStore = ProductDaoMemory.GetInstance();
            IProductCategoryDao productCategoryDataStore = ProductCategoryDaoMemory.GetInstance();
            ISupplierDao supplierDataStore = SupplierDaoMemory.GetInstance();

            Supplier bell = new Supplier{Name = "Bell", Description = "Kaski"};
            supplierDataStore.Add(bell);
            Supplier imx = new Supplier{Name = "Imx", Description = "Kaski"};
            supplierDataStore.Add(imx);
            Supplier hjc = new Supplier { Name = "HJC", Description = "Kaski" };
            supplierDataStore.Add(hjc);
            ProductCategory helmet = new ProductCategory {Name = "Kaski", Department = "Ochraniacze", Description = "Kaski" };
            productCategoryDataStore.Add(helmet);
            ProductCategory jackets = new ProductCategory { Name = "Kurtki", Department = "Odzie¿", Description = "Odzie¿ i ochraniacze" };
            productCategoryDataStore.Add(jackets);
            ProductCategory pants = new ProductCategory { Name = "Spodnie", Department = "Odzie¿", Description = "Odzie¿ i ochraniacze" };
            productCategoryDataStore.Add(pants);
            ProductCategory googgles = new ProductCategory { Name = "Gogle", Department = "Ochaniacze", Description = "Gogle" };
            productCategoryDataStore.Add(googgles);
            productDataStore.Add(new Product { Name = "IMX FMX 02", DefaultPrice = 99.9m, Currency = "USD", Description = "Kask motocyklowy do jazdy na cross IMX FM-02\r\nKask motocyklowy w którym znajdziesz wydajny system wentylacyjny, wyjmowane poduszki policzkowe i zapiêcie mikrometryczne. Skorupa tego modelu zosta³a wykonana z najwy¿szej jakoœci materia³ów ABS.\r\n\r\nHomologacja ECE 22.05\r\nSkorupa ABS\r\nZapiêcie mikrometryczne\r\n2 wielkoœci EPS\r\nAwaryjne wypiêcie poduszek policzkowych", ProductCategory = helmet, Supplier = imx });
            productDataStore.Add(new Product { Name = "Lenovo IdeaPad Miix 700", DefaultPrice = 479.0m, Currency = "USD", Description = "Keyboard cover is included. Fanless Core m5 processor. Full-size USB ports. Adjustable kickstand.", ProductCategory = helmet, Supplier = imx });
            productDataStore.Add(new Product { Name = "Amazon Fire HD 8", DefaultPrice = 89.0m, Currency = "USD", Description = "Amazon's latest Fire HD 8 tablet is a great value for media consumption.", ProductCategory = helmet, Supplier = bell });
            productDataStore.Add(new Product { Name = "zjebanyKask", DefaultPrice = 89.0m, Currency = "USD", Description = "Amazon's latest Fire HD 8 tablet is a great value for media consumption.", ProductCategory = helmet, Supplier = bell });
        }
    }
}
