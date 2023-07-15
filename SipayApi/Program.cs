using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace WebApplication1
{
    // Bir dotnet uygulamasý ayaða kalktýðýnda ilk olarak Program.cs çalýþýr.(Ýlk initialization ettiði yerdir.)
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run(); 
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>    //Host ayaða kaldýrýlýyor. 
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();  //Host için startup config'i kullanmasýný söylüyor. Web uygulamalýrýný standart olarak kullandýðý yöntemdir.
                    //Console uygulamasý üzerinden bir port üzerinden çalýþan uygulama ayaða kalkýyor. Browser'da çalýþan bir web uygulamasý geliþtiriliyor.
                    //Browser'da swagger(Api dokümantasyon aracý) aracýlýðýyla kodlar yorumlanarak bir dokumantasyon sayfasý oluþturuluyor.
                });

    
        /// <summary> 
        ///
        ///Swagger UI:
        ///Bir .net core web api projesi yarattýðýmýzda proje içerisine varsayýlan(Default) olarak swagger ui eklentisi eklenmiþ olarak gelir.
        ///Swagger UI, oluþturduðumuz API'lar ile ilgili bilgileri görselleþtirmemiz ve otomatik dökümantasyon oluþturabilmemize yarayan yardýmcý bir arayüzdür.
        ///Bu arayüz sayesinde web api projemizde hangi resource'lara sahip olduðumuzu ve bu resourcelarla ilgili hangi eylemleri yapabileceðimizle ilgili bir dökümantasyon oluþturmuþ oluruz.
        ///Bu sayede hem ekip içindeki, hem de API'mizi kullanacak diðer geliþtirici arkadaþlarýn bilgi sahibi olmasýný saðlamýþ oluruz.

        ///Swagger UI içerisinde bir eylemle ilgili olarak temel iki çeþit bilgi bulunur:
        ///1) Parameters : Http Put ve Http Post çaðrýmlarýnýn beklediði parametreleri gördüðümüz yerdir.
        ///2) Responses : Http talebine karþýlýk olarak nasýl bir HTTP response'u oluþturabileceðini, response içerisinde hangi tipte bir data döneceðini detaylý olarak görebiliriz.
        ///****** Swagger UI aracýlýðý ile eylemlerin beklediði parametreleri kolay bir þekilde doldurarak örnek çaðrýmlar yapabilir, dönen cevaplarý gözlemleyebiliriz.
        /// 
        /// </summary>


        ///<summary>
        ///## Postman Kullanýmý:
        /// Postman bir API platformudur. API geliþtirmek, test etmek ve/veya hazýr bir API kullanýmý için gerekli isteklerde bulunabileceðimiz bir uygulamadýr.
        /// Insomnia REST Client, HTTPie gibi alternatifleri de bulunmasýna karþýn en çok kullanýlan API aracýdýr.
        /// Postman Kullaným Senaryolarý:
        /// Bir uygulama geliþtirmek istiyoruz ve geliþtirmeye baþlamada kullanmak istediðimiz ücretli veya ücretsiz bir REST API tarafýna ilgili istekleri göndererek gelen sunumlarý inceleyebiliriz.
        /// </summary>


    }
}
