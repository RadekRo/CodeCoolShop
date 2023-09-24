using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
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

            Supplier bell = new Supplier{Name = "Bell", Description = "Helmets"};
            supplierDataStore.Add(bell);
            Supplier imx = new Supplier{Name = "Imx", Description = "Helmets"};
            supplierDataStore.Add(imx);
            Supplier hjc = new Supplier { Name = "HJC", Description = "Helmets" };
            supplierDataStore.Add(hjc);
            Supplier broger = new Supplier { Name = "BROGER", Description = "Jackets" };
            supplierDataStore.Add(broger);
            Supplier giro = new Supplier { Name = "GIRO", Description = "Pants" };
            supplierDataStore.Add(giro);
            Supplier gogler = new Supplier { Name = "Gogler", Description = "Gogles" };
            supplierDataStore.Add(gogler);
            ProductCategory helmet = new ProductCategory {Name = "Helmets", Department = "Protectors", Description = "Kaski" };
            productCategoryDataStore.Add(helmet);
            ProductCategory jackets = new ProductCategory { Name = "Jackets", Department = "Clothes", Description = "Clothing and protectors." };
            productCategoryDataStore.Add(jackets);
            ProductCategory pants = new ProductCategory { Name = "Pants", Department = "Clothes", Description = "Clothing and protectors." };
            productCategoryDataStore.Add(pants);
            ProductCategory googgles = new ProductCategory { Name = "Gogle", Department = "Protectors", Description = "Gogle" };
            productCategoryDataStore.Add(googgles);
            productDataStore.Add(new Product { Name = "IMX FMX 02", DefaultPrice = 99.9m, Currency = "USD", Description = "Motorcycle helmet for motocross IMX FM-02 A motorcycle helmet that features an efficient ventilation system, removable cheek pads, and a micrometric fastening system. The shell of this model is made from high-quality ABS materials. ECE 22.05 homologation ABS shell Micrometric fastening system 2 EPS sizes Emergency cheek pad release\r\n\r\nHomologacja ECE 22.05\r\nSkorupa ABS\r\nZapiêcie mikrometryczne\r\n2 wielkoœci EPS\r\nAwaryjne wypiêcie poduszek policzkowych.", ProductCategory = helmet, Supplier = imx });
            productDataStore.Add(new Product { Name = "HJC Helmet", DefaultPrice = 179.0m, Currency = "USD", Description = "Just a normal helmet, gives a certain chance to safe the user from certain death", ProductCategory = helmet, Supplier = hjc });
            productDataStore.Add(new Product { Name = "Broozer", DefaultPrice = 479.0m, Currency = "USD", Description = "Jaw Helmet BELL BROOZER SOLID MATTE BLACK", ProductCategory = helmet, Supplier = bell });
            productDataStore.Add(new Product { Name = "BROGER MONTANA BLACK", DefaultPrice = 89.0m, Currency = "USD", Description = "Jacket BROGER MONTANA BLACK", ProductCategory = jackets, Supplier = broger });
            productDataStore.Add(new Product { Name = "Helmy helmet", DefaultPrice = 89.0m, Currency = "USD", Description = "Protects your skull and brain", ProductCategory = helmet, Supplier = bell });
            productDataStore.Add(new Product { Name = "Shima Giro 2.0", DefaultPrice = 89.0m, Currency = "USD", Description = "Tactical pants in safe, motocyclical edition is model Shima Giro 2.0\r\n", ProductCategory = pants, Supplier = giro });
            productDataStore.Add(new Product { Name = "Gogles", DefaultPrice = 289.0m, Currency = "USD", Description = "Protects your face and eyes, you can stay beautiful for longer\r\n", ProductCategory = googgles, Supplier = gogler });
        }
    }
}
