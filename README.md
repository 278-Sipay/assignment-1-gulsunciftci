[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/0mNoXTBm)
# assignment-1

# Hafta 1 Fluent Validation Ders Ödevi

# Ödevde İstenenler:

Appendix
Person class icersindeki validation lar FluentValidation kutuphanesi kullanilarak yeniden duzenlenecek. Controller uzerindeki POST methodu attributelar yerinde FluentValidation ile calisacak sekilde duzenlenecek. Odev icerisinde sadece 1 controller ve 1 method teslim edilecek.
``` C#
public class Person
{
    [DisplayName("Staff person name")]
    [Required]
    [StringLength(maximumLength: 100, MinimumLength = 5)]
    public string Name { get; set; }


    [DisplayName("Staff person lastname")]
    [Required]
    [StringLength(maximumLength: 100, MinimumLength = 5)]
    public string Lastname { get; set; }


    [DisplayName("Staff person phone number")]
    [Required]
    [Phone]
    public string Phone { get; set; }


    [DisplayName("Staff person access level to system")]
    [Range(minimum: 1, maximum: 5)]
    [Required]
    public int AccessLevel { get; set; }



    [DisplayName("Staff person salary")]
    [Required]
    [Range(minimum: 5000, maximum: 50000)]
    [SalaryAttribute]
    public decimal Salary { get; set; }
}
```
## Proje Visual Studion 2022 kullanılarak Asp.Net Core 6.0 Web Api projesi olarak oluşturulmuştur.

Merhaba, Proje anlatımına geçmeden önce ilk olarak önemli olduğunu düşündüğüm birkaç terimin açıklamasına ve kullanım alanlarına bakalım.

## API (Application Programming Interface) Nedir :

* En basitleştirilmiş tanımıyla API; Bir kod bölümünün başka bir kod bölümüyle iletişime geçmesidir.(Genel olarak iki yazılımın birbiriyle iletişime geçmesidir.)
* Bir yazılımın gerçekleştirebildiği işlemlere belirli koşullar dahilinde dışarıdan erişilip bu işlemlerin kullanılmasını sağlayan arayüzdür.
* API'ların kullanımında kendi yazdığımız uygulamalar ile kullandığımız API'lar farklı programlama dillerine sahip olabilirler 
* Ayrıca API'lar platform bağımsız çalışırlar.
* Özetle, bir uygulamada gerçekleştirmek istediğimiz ek bir işlemi, o işlemi sağlayan başka bir uygulamadan API kullanarak gerçekleştirebiliriz.

## Neden API Kullanırız?

* API kullanımı bizi ilgili işlemin gerektireceği iş yükünden kurtarır. “API hayatı kolaylaştırır”.
* API lar özel kullanıcı kitlelerine yönelik hazırlanırlar ve ilgili verileri hızlı bir şekilde oluşturmamızı sağlarlar. ( IMDB API, GitHub API ..)
* Platform bağımsız çalışırlar.
* Güncelleme durumunda bizim yapmamız gereken işlemler sınırlıdır.


![API](https://upload.wikimedia.org/wikipedia/commons/3/36/Web_API.png)

## API Kulanımının Avantajları

* Platform bağımsız olmaları
* Verimliliği arttırmaları
* İlgili verilere kolay ulaşım
* İş yükünün azalması

## HTTP Metotları
1) GET:  Verileri almak - listelemek için kullanılan istek metodudur.
2) POST: Belirli bir kaynağa veri göndermek için kullanılır.
3) PUT:  Belirli bir kaynaktaki verinin tamamının değiştirilmesi için kullanılan metodtur.
4) PATCH: Belirli bir kaynaktaki verilerin bir kısmının değiştirilmesi için kullanılan metodtur.
5) DELETE: Belirli bir kaynaktaki verilerin silinmesi için kullanılan metodtur.


## Postman Kullanımı:
* Postman bir API platformudur. 
* API geliştirmek , test etmek ve/veya hazır bir API kullanımı için gerekli isteklerde bulunabileceğimiz bir uygulamadır. 
* Insomnia REST Client, HTTPie gibi alternatifleri de bulunmasına karşın en çok kullanılan API aracıdır.

## Postman Kullanım Senaryoları:
* Bir uygulama geliştirmek istiyoruz ve geliştirmeye başlamada kullanmak istediğimiz ücretli veya ücretsiz bir REST API tarafına ilgili istekleri göndererek gelen sunumları inceleyebiliriz.

## Swagger UI Nedir ?
* Swagger UI, oluşturduğumuz API'lar ile ilgili bilgileri görselleştirmemiz ve otomatik dökümantasyon oluşturabilmemize yarayan yardımcı bir arayüzdür. 
* Bu arayüz sayesinde web api projemizde hangi resource'lara sahip olduğumuzu ve bu resourcelarla ilgili hangi eylemleri yapabileceğimizle ilgili bir dökümantasyon oluşturmuş oluruz. 
* Bu sayede hem ekip içindeki, hem de API'mizi kullanacak diğer geliştirici arkadaşların bilgi sahibi olmasını sağlamış oluruz.
* Bir .net core web api projesi yarattığımızda proje içerisine varsayılan olarak swagger ui eklentisi eklenmiş olarak gelir.

## Swagger UI içerisinde bir eylemle ilgili olarak temel iki çeşit bilgi bulunur.

1) Parameters : Http Put ve Http Post çağrımlarının beklediği parametreleri gördüğümüz yerdir.
2) Responses : Http talebine karşılık olarak nasıl bir HTTP response'u oluşturabileceğini, response içerisinde hangi tipte bir data döneceğini detaylı olarak görebiliriz.

* Swagger UI aracılığı ile eylemlerin beklediği parametreleri kolay bir şekilde doldurarak örnek çağrımlar yapabilir, dönen cevapları gözlemleyebiliriz.




Umarım açıklamalar proje'yi daha iyi anlama açısından faydası olmuştur. Fluent validation işlemlerini yapabilmek için Nuget Package Manager'dan FluentValidation.AspNetCore ve FluentValidation paketlerini yükledim. Bu işlemi yaptıktan sonra fluent validation servisini Startup.cs ConfigureServices bölümüne aşağıda ki kod satırını ekleyerek entegre ettim. 

```C#
services.AddControllersWithViews().AddFluentValidation(x=>x.RegisterValidatorsFromAssemblyContaining<Startup>());
```

* Daha sonra Models katmanına Person modelini ekleyerek property'leri oluşturdum. 

```C#
public class Person
{
        
        public string Name { get; set; }

    
        public string LastName { get; set; }

       
        public DateTime Phone { get; set; }

       
        public int AccessLevel { get; set; }


        public decimal Salary { get; set; }

}
```  
* Models katmanında Validators dosyasını açarak Person class'ına ait fluent validation işlemlerini yapmak üzere PersonValidator class'ını ekledim. Tüm bu adımları tamamlandıktan sonra class'ın içerisine validation kodlarını yazdım.

```C#
public PersonValidator()
{
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(x => x.Name).MinimumLength(5).MaximumLength(100).WithMessage("Name length can be at least 5 and up to 100"); ;


            RuleFor(x => x.LastName).NotEmpty().WithMessage("LastName cannot be empty");
            RuleFor(x => x.LastName).MinimumLength(5).MaximumLength(100).WithMessage("Lastname length can be at least 5 and up to 100");

            RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone cannot be empty");


            RuleFor(x => x.AccessLevel).NotEmpty().WithMessage("AccessLevel cannot be empty");
            RuleFor(x => x.AccessLevel).InclusiveBetween(1, 5).WithMessage("AccessLevel should be between 1 and 5");


            RuleFor(x => x.Salary).NotEmpty().WithMessage("Salary cannot be empty");
            RuleFor(x => x.Salary).InclusiveBetween(5000, 50000).WithMessage("Salary should be between 5000 and 50000");


}
    
```
## FluentValidation Nedir?
* Bir veri doğrulama kütüphanesidir.
* FluentValidation ve benzeri ürünlerin kullanılması, verilerin doğru şekilde yani verilerin oluştururken konulmuş kısıtlamaları sağlayarak kurallara uyumlu halde olmasını ve kullanıcı ya da sistem kaynaklı hataların oluşmasını engeller.



## Badges

Add badges from somewhere like: [shields.io](https://shields.io/)

[![MIT License](https://img.shields.io/badge/License-MIT-green.svg)](https://choosealicense.com/licenses/mit/)
[![GPLv3 License](https://img.shields.io/badge/License-GPL%20v3-yellow.svg)](https://opensource.org/licenses/)
[![AGPL License](https://img.shields.io/badge/license-AGPL-blue.svg)](http://www.gnu.org/licenses/agpl-3.0)

