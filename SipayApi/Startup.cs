using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1   
{
    /// <summary>
    /// net6.0 içerisinde startup.cs yok. Þu anda net6.0 kullanýyoruz startup.cs ve program.cs dosyalarýný oradan kopyaladýk.
    /// uygulamamýz için gerekli ayarlarý yapabilmemiz için Startup.cs dosyasýndaki Startup class'ý varsayýlan ayarlar ile kurulu olarak oluþturulur.
    /// Bu class içerisindeki ayarlar ile uygulamamýzýn nasýl davranacaðýný, hangi bileþenleri kullanacaðýný belirtmiþ oluruz.
    /// uygulama içerisinde kullanýlacak konfigurasyon dosyasý Startup.cs dir.
    /// Startup.cs içerisinde 2 adet temel metot bulunur. Bu metotlar aracýlýðý ile uygulamamýzýn ayarlarýný oluþtururuz.
    /// </summary>

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        ///
        /// Bu metot aracýlýðý ile uygulamamýzýn içerisinde kullanacaðýmýz bileþenlerin ayarlarýný yapabiliriz. 
        /// ConfigureServices metodu içerisinde uygulamanýn kullanacaðý servisler ve Dependency Injection'lar(DI) eklenir ve konfigüre edilir.
        /// Servisleriyse belli bir iþi yapmaktan sorumlu kod parçalarý, sýnýflar yada kütüphaneler gibi düþünebilirsiniz. Kýsaca onlara bileþenler de diyebiliriz.
        /// </summary>

        public void ConfigureServices(IServiceCollection services)
        {
            //fluentvalidation servisini entegre ettim
            services.AddControllersWithViews().AddFluentValidation(x=>x.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.AddControllers();
            services.AddSwaggerGen(c => //swagger implementasyonu otomatik yapýlmýþ geliyor
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApplication1", Version = "v1" });
            });
        }

        /// <summary>
        /// Bu metot uygulamamýza gelen HTTP isteklerini hangi aþamalardan geçirerek bir HTTP cevabý oluþturacaðýmýzý belirttiðimiz metottur. 
        /// Startup içerisinde bu metodun doldurulmasý ve doðru ayarlarlanmasý gereklidir.
        /// Middleware'ler kullanýlarak uygulama içerisinde bir pipeline oluþturulur. Ýþte bu pipeline configure() dosyasý içerisinde belirlenir.
        /// </summary>

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger(); 
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication1 v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
     
    }
}
