using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
            services.AddSession();

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
            app.UseSession();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Product}/{action=Index}/{id?}");
            });

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
            Supplier broger = new Supplier { Name = "BROGER", Description = "Kurtki" };
            supplierDataStore.Add(broger);
            Supplier giro = new Supplier { Name = "GIRO", Description = "Spodnie" };
            supplierDataStore.Add(giro);
            ProductCategory helmet = new ProductCategory {Name = "Kaski", Department = "Ochraniacze", Description = "Kaski" };
            productCategoryDataStore.Add(helmet);
            ProductCategory jackets = new ProductCategory { Name = "Kurtki", Department = "Odzie¿", Description = "Odzie¿ i ochraniacze" };
            productCategoryDataStore.Add(jackets);
            ProductCategory pants = new ProductCategory { Name = "Spodnie", Department = "Odzie¿", Description = "Odzie¿ i ochraniacze" };
            productCategoryDataStore.Add(pants);
            ProductCategory googgles = new ProductCategory { Name = "Gogle", Department = "Ochaniacze", Description = "Gogle" };
            productCategoryDataStore.Add(googgles);
            productDataStore.Add(new Product { Name = "IMX FMX 02", DefaultPrice = 99.9m, Currency = "USD", Description = "Kask motocyklowy do jazdy na cross IMX FM-02\r\nKask motocyklowy w którym znajdziesz wydajny system wentylacyjny, wyjmowane poduszki policzkowe i zapiêcie mikrometryczne. Skorupa tego modelu zosta³a wykonana z najwy¿szej jakoœci materia³ów ABS.\r\n\r\nHomologacja ECE 22.05\r\nSkorupa ABS\r\nZapiêcie mikrometryczne\r\n2 wielkoœci EPS\r\nAwaryjne wypiêcie poduszek policzkowych", ProductCategory = helmet, Supplier = imx });
            productDataStore.Add(new Product { Name = "broozer", DefaultPrice = 479.0m, Currency = "USD", Description = "Kask szczêkowy BELL BROOZER SOLID MATTE BLACK czarny", ProductCategory = helmet, Supplier = bell });
            productDataStore.Add(new Product { Name = "MONTANA", DefaultPrice = 89.0m, Currency = "USD", Description = " Kurtka tekstylna BROGER MONTANA BLACK czarny", ProductCategory = jackets, Supplier = broger });
            productDataStore.Add(new Product { Name = "zjebanyKask", DefaultPrice = 89.0m, Currency = "USD", Description = "Amazon's latest Fire HD 8 tablet is a great value for media consumption.", ProductCategory = helmet, Supplier = bell });
            productDataStore.Add(new Product { Name = "giro", DefaultPrice = 89.0m, Currency = "USD", Description = " Taktyczne bojówki w bezpiecznym, motocyklowym wydaniu to model spodni Shima Giro 2.0\r\n", ProductCategory = pants, Supplier = giro });

        }
    }
}
