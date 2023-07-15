using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SipayApi.Controllers
{
    [Route("api/[controller]")] //Route attribute, metotlara erişirken kullanılacak yol
    [ApiController] //Api controller Attribute bunun bir api controlle  attribute olduğunu gösteriyor.
    public class ValuesController : ControllerBase //Bir controller bir class'tan inherit(miras) almış.
    {
        ///Not:Browserda sadece get olarak metotları default olarak çalıştırabiliriz
        /// Diğer metotlar için harici uygulama gerekli(Postman,Swagger)

        ///<summary>
        /// **** API (Application Programming Interface) Nedir :
        /// En basitleştirilmiş tanımıyla API; Bir kod bölümünün başka bir kod bölümüyle iletişime geçmesidir.(Genel olarak iki yazılımın birbiriyle iletişime geçmesidir.)
        /// Bir yazılımın gerçekleştirebildiği işlemlere belirli koşullar dahilinde dışarıdan erişilip bu işlemlerin kullanılmasını sağlayan arayüzdür.
        /// API'ların kullanımında kendi yazdığımız uygulamalar ile kullandığımız API'lar farklı programlama dillerine sahip olabilirler. 
        /// Ayrıca API'lar platform bağımsız çalışırlar.
        /// </summary>


        ///<summary>
        /// **** Neden API Kullanırız?
        /// API kullanımı bizi ilgili işlemin gerektireceği iş yükünden kurtarır. “API hayatı kolaylaştırır”.
        /// API lar özel kullanıcı kitlelerine yönelik hazırlanırlar ve ilgili verileri hızlı bir şekilde oluşturmamızı sağlarlar. ( IMDB API, GitHub API ..)
        /// Platform bağımsız çalışırlar.
        /// Güncelleme durumunda bizim yapmamız gereken işlemler sınırlıdır.
        /// </summary>

        ///<summary>
        /// **** REST API Nedir?
        /// Representational state transfer; İlgili isteğe karşılık gelen verinin JSON / XML gibi dosya formatlarında gönderilmesidir. 
        /// REST API, REST mimarisinin prensiplerine taşıyan API’lardır. Tüm prensiplerin karşılanması durumunda RESTful API olarak da adlandırılır.
        /// Özetle, bir uygulamada gerçekleştirmek istediğimiz ek bir işlemi, o işlemi sağlayan başka bir uygulamadan API kullanarak gerçekleştirebiliriz.
        /// </summary>

        ///<summary>
        /// **** REST Prensipleri:
        /// 1) İstemci – Sunucu: (Client – Server)
        /// İstemci isteği gönderen, sunucu da ilgili cevabı veren durumundadır. 
        /// Birbirlerinin sorumluluk alanlarına girmezler. Birbirlerinden bağımsız programlama dilleri ve teknolojiler kullanabilirler.
        /// 2) Tek Tip Arayüz: (Uniform Interface)
        /// Aynı kaynağa yönelik olan tüm istekler, isteğin nereden geldiğinden bağımsız olarak aynı şekilde görünmelidir. 
        /// Bu aynı zamanda istemci – sunucu bağımsızlığını da destekler. 4 temel özelliği bulunmaktadır.
        /// 3) Durumsuzluk: (Statelessness)
        /// STATE: Söz konusu veriyi - durumu belirtir, örneğin bir veritabanı için düşünürsek veritabanında o an için bulunan veridir. 
        /// Bir React uygulamasını düşünürsek herhangi bir component’ın o an ki durumu. Modal’ın açık veya kapalı olması, kullanıcının giriş, çıkış durumu gibi.
        /// Stateful ( Durum bilgisi olan ) vs Stateless ( Durum bilgisi olmayan ) İstemci tafından gerçekleştirilen her istek birbirinden bağımsızdır 
        /// ve sunucu bu isteklerin her birini bağımsız olarak değerlendirir. 
        /// Sunucu istemci tarafından kendisine gönderilen bilgileri tutmamalıdır. 
        /// Örneğin bir isteğimiz kimlik doğrulama (Authentication) işlemi gerektiriyorsa ilgili tüm bilgiler (token vs..) istemci tarafından sunucuya devamlı olarak gönderilmelidir.
        /// 4) Önbelleklenebilir: (Cacheable)
        /// Sunucu gelen isteklere verilen cevapların önbelleklenebilir olup olmadığını belirtmelidir. 
        /// Örneğin “Cache-Control”, “Expires” gibi HTTP başlıkları önbellek ile ilgili bilgiler taşır.
        /// 5) Katmanlı Sistem: (Layered System)
        /// İstemci – sunucu arasındaki ilişki katmanlara ayrılabilir, ve bileşenler sadece ilişkili oldukları katmanlara karşı sorumlu olurlar.
        /// 6) İsteğe Bağlı Kod: (Code On Demand - Optional)
        /// Sunucu, istemci tarafına istemcinin işlevini genişletecek ek kodlar gönderebilir.
        /// Bu özellik istemci tarafında yapılması gereken işlemleri hafifletir.
        /// Örneğin sunucu, istemci tarafına döneceği HTML dökümanın içerisine JavaScript kodları ekleyebilir.
        /// </summary>


        ///<summary>
        /// **** HTTP Nedir? 
        /// Hyper Text Transfer Protocol ifadesinin kısaltmasıdır. 
        /// İstemci ile sunucu arasındaki veri akışının kurallarını belirleyen protokoldür. İstek – Cevap (request, response) modeline göre çalışır.
        /// </summary>


        ///<summary>
        /// **** REST Mimarisinde HTTP'nin Rolü: 
        /// REST mimarisinin prensiplerinden ilki istemci - sunucu çalışma modelidir. 
        /// Biz bir istekte bulunuruz ve sunucu isteğimize karşılık olan durumu (state) bize bir sunum (presentation) olarak gönderir. 
        /// HTTP protokolü burada bu sunum transferi için kurulan iletişimin kurallarını belirler. REST mimarisine uygun API'ların neredeyse tamamında HTTP protokolü kullanılır.
        /// </summary>
        /// 

        ///<summary>
        /// **** HTTP Durum Kodları (Status Codes):
        /// Sunucu tarafından ilgili isteğin sonucunu belirten, 3 rakamdan oluşan sayısal ifadelerdir.
        /// 1) Informational responses (Bidirimsel cevaplar) (100–199):
        /// 100 Continue
        /// 102 Processing
        /// 2) Successful responses (Başarılı cevaplar) (200–299):
        /// 200 OK
        /// 201 Created
        /// 204 No Content
        /// 3) Redirections (Yönlendirme cevapları) (300–399)
        /// 300 Multiple Choice
        /// 301 Moved Permanently
        /// 304 Not Modified
        /// 4) Client errors (İstemci Hataları) (400–499)
        /// 400 Bad Request
        /// 401 Unauthorized
        /// 403 Forbidden
        /// 404 Not Found
        /// 405 Method Not Allowed
        /// 5) Server errors (Sunucu Hataları) (500–599)
        /// 500 Internal Server Error
        /// 503 Service Unavailable
        /// </summary>


        ///<summary>
        /// **** JSON Nedir?
        /// Veri depolamak veya veri iletmek için kullanılan metin tabanlı bir söz dizimi yapısıdır.
        /// JavaScript Object Notation ifadesinin kısaltmasıdır. 
        /// Genellikle bir sunucu ve istemci arasında veri alışverişi için veya yazılımların genel ayarları için kullanılan bir formattır.
        /// </summary>

        ///<summary>
        /// **** JSON Veri Tipleri
        /// 1) String: "Sample String", "test1234", "A"
        /// 2) Number: 7, 3.2, -97.238
        /// 3) Boolean: true, false
        /// 4) Null: null
        /// 5) Array: [2,3,5,7] , ["İstanbul", "Ankara", "İzmir"] Array içerisinde kullanılan değerler sıralı olarak listelenebilir.
        /// 6) Object { "name": "Gürcan", "age":40 } JSON nesneleri verileri key-value çiftleri olarak tanımlar.
        /// Yukarıda görmüş olduğunuz veri tiplerinin tamamı tekil olarak uygun bir JSON formatı işlevini görür.
        /// Ancak tek bir 3, string veya true gibi ifadeler için ayrı bir .json uzantılı dosya oluşturmak mantıklı değildir.
        /// Bu nedenle JSON doayaları bir array, nesne ve/veya bunların içiçe geçmiş formlarından oluşur.
        /// </summary>


        ///<summary>
        /// **** JSON vs JavaScript
        /// JavaScript web uygulamalarında sıklıkla kullanılan dinamik bir programlama dilidir.
        /// Bu nedenle uygun JSON formatındaki bir içerik JavaScript ifadesine (expression) denk gelir.
        /// JSON ise bir söz dizim olarak JavaScript'in bir alt kümesi olarak düşünülebilir.
        /// JSON söz dizimini bir JavaScript değişkenine atadığımızda, değişken değer olarak bir JavaScript nesnesini almış olur.
        /// JSON formatında key ifadelerin çift tırnak içerisine alınması zorunludur. 
        /// Her ne kadar JSON söz dizimi olarak kendisine JavaScript'i örnek aldıysa da kullanımı bir çok programlama dili tarafında yaygındır.
        /// </summary>

        ///<summary>
        /// **** JSON vs XML
        /// XML, eXtensible Markup Language ifadesinin kısaltmasıdır. Veri depolamak ve iletmek için kullanılan bir script dilidir. 1998 yılında W3C tarafından standartlaştırılmıştır.
        /// Genel olarak ağaç yapısına (tree structure) sahiptir. 
        /// Veriler açılış ve kapanış etiketlerinin içerisinde bulunur.
        /// Dıştaki etiket, içtekinin "parent"ı, içteki etiket ise dıştakinin "child"ı şeklinde düşünülür.
        /// JSON formatının XML formatına göre en büyük avantajı, doğalında bir nesne modeline sahip olmasıdır. 
        /// Bu özellik sayesinde birçok programlama dili JSON verileri daha kolay bir şekilde işleyebilir. 
        /// </summary>


        ///<summary>
        /// **** Postman Kullanımı:
        /// Postman bir API platformudur. 
        /// API geliştirmek , test etmek ve/veya hazır bir API kullanımı için gerekli isteklerde bulunabileceğimiz bir uygulamadır. 
        /// Insomnia REST Client, HTTPie gibi alternatifleri de bulunmasına karşın en çok kullanılan API aracıdır.
        /// **** Postman Kullanım Senaryoları:
        /// Bir uygulama geliştirmek istiyoruz ve geliştirmeye başlamada kullanmak istediğimiz ücretli 
        /// veya ücretsiz bir REST API tarafına ilgili istekleri göndererek gelen sunumları inceleyebiliriz.
        /// Harici olarak kurulması gerekir. Swagger'a göre daha gelişmiştir
        /// </summary>


        /// <summary> 
        ///
        ///Swagger UI:
        ///Bir .net core web api projesi yarattığımızda proje içerisine varsayılan(Default) olarak swagger ui eklentisi eklenmiş olarak gelir.
        ///Swagger UI, oluşturduğumuz API'lar ile ilgili bilgileri görselleştirmemiz ve otomatik dökümantasyon oluşturabilmemize yarayan yardımcı bir arayüzdür.
        ///Bu arayüz sayesinde web api projemizde hangi resource'lara sahip olduğumuzu ve bu resourcelarla ilgili hangi eylemleri yapabileceğimizle ilgili bir dökümantasyon oluşturmuş oluruz.
        ///Bu sayede hem ekip içindeki, hem de API'mizi kullanacak diğer geliştirici arkadaşların bilgi sahibi olmasını sağlamış oluruz.
        ///Otomatik olarak generate olur. Swagger'ı daha çok geliştiriciler kullanır, postman'ı ise tester tarafında çalışan kişiler

        ///Swagger UI içerisinde bir eylemle ilgili olarak temel iki çeşit bilgi bulunur:
        ///1) Parameters : Http Put ve Http Post çağrımlarının beklediği parametreleri gördüğümüz yerdir.
        ///2) Responses : Http talebine karşılık olarak nasıl bir HTTP response'u oluşturabileceğini, response içerisinde hangi tipte bir data döneceğini detaylı olarak görebiliriz.
        ///****** Swagger UI aracılığı ile eylemlerin beklediği parametreleri kolay bir şekilde doldurarak örnek çağrımlar yapabilir, dönen cevapları gözlemleyebiliriz.
        /// 
        /// </summary>




        ///<summary>
        ///Nitelikler(Attributes):
        ///. Net Framework' de var olan veya geliştiriciler tarafından yazılan tip(type) veya 
        ///üyelere(members) çalışma zamanında davranışlarının farklı şekillerde ele alınabilmelerini sağlayan ekstra metadata (veri hakkında veri) bilgileri ekler.
        /// </summary>






        /// <summary>
        /// **** Get:
        /// Bu metod sunucudan veri almak için kullanılır. 
        /// Bunun en önemli faydası kullanıcıların bookmark edebilmeleri ve aynı sorguyu içeren istekleri daha sonra gönderebilmelerini sağlaması ve 
        /// tarayıcıda önceki sorguların “geri” tuşu ile veya tarayıcı geçmişinden çağrılarak aynı sayfalara ulaşabilmeleridir.
        /// Güvenlik açısından URL’lerin ekranda görüntüleniyor olması ve 
        /// URL’in hedefine ulaşıncaya kadar ve hedef sunucu üzerinde iz kayıtlarında görülebilmesi gönderilen parametrelerin gizlilik ihtiyacı varsa sıkıntı yaratabilir. 
        /// Bu nedenlerle hassas istekler GET ile gönderilmemelidir.
        /// GET ve POST metodları en sık kullanılan metodlar olup sunucudaki kaynaklara erişmek için kullanılırlar.
        /// Kendimizin bir REST API oluşturduğu bir senaryoyu düşünelim. Geliştirme aşamasında Postman yardımıyla gelen isteklere karşı uygulamamızın vereceği cevapları test edebiliriz.
        /// </summary>
        /// <returns>Liste olarak string dönüyor</returns>

        [HttpGet]
        public IEnumerable<string> Get() //Http metot(Http Request Method)
        {
            return new string[] { "value1", "value2" };
        }


        [HttpGet("{id}")] //Http metot'unun tipini belirtir
        public string Get(int id) //id parametre alıp string dönüyor.
        {
            return "value";
        }

        /// <summary>
        /// **** POST:
        /// Bu metod ile sunucuya veri yazdırabilirsiniz. 
        /// Bu metodla istek parametreleri hem URL içinde hem de mesaj gövdesinde gönderilebilir.
        /// Sadece mesaj gövdesinin kullanımı yukarıda sayılan riskleri engelleyecektir. 
        /// Tarayıcılar geri butonuna basıldığında POST isteğinin mesaj gövdesinde yer alan parametreleri tekrar göndermek isteyip istemedimizi sorarlar. 
        /// Bunun temel nedeni bir işlemi yanlışlıkla birden fazla yapmayı engellemektir. 
        /// Bu özellik ve de güvenlik gerekçeleriyle bir işlem gerçekleştirileceğinde POST metodunun kullanılması önerilir.
        /// </summary>
        /// <returns>Liste olarak string dönüyor</returns>
        
        [HttpPost]
        public void Post([FromBody] string value) //Http metot(Http Request Method)
        {
        }

        /// <summary>
        /// **** PUT:
        /// Bu metod ile servis sağlayıcı üzerindeki bir kaynağı güncelleyebilirsiniz. 
        /// Hangi kaynağı güncelleyecekseniz o kaynağın id’sini göndermek zorunludur.
        /// </summary>
        /// <returns>Liste olarak string dönüyor</returns>

        [HttpPut("{id}")] //Attribute 
        public void Put(int id, [FromBody] string value) //Http metot(Http Request Method)
        {
        }


        /// <summary>
        /// **** DELETE:
        /// Bu metod ile sunucudaki herhangi bir veriyi silebilirsiniz.
        /// </summary>
        /// <returns>Liste olarak string dönüyor</returns>
        
        [HttpDelete("{id}")]
        public void Delete(int id) //Http metot(Http Request Method)
        {
        }


        ///<summary>
        /// **** DİĞER HTTP METOTLARI: 
        /// 1) HEAD:
        ///  GET metoduyla benzer işleve sahiptir ancak geri dönen yanıtta mesaj gövdesi bulunmaz (yani başlıklar ve içerikleri GET metoduyla aynıdır). 
        ///  Bu nedenle GET mesajı gönderilmeden önce bir kaynağın var olup olmadığını kontrol etmek için kullanılabilir.
        /// 2) CONNECT:
        /// Bir proxy sunucu üzerinden başka bir sunucuya bağlanmak ve proxy sunucuyu bir tünel gibi kullanmak için kullanılır.
        /// 3) OPTIONS:
        /// Bu metot belli bir kaynak için kullanılabilecek HTTP metotlarını sunucudan sorgulamak için kullanılır.
        /// 4) TRACE:
        /// Teşhis amaçlı kullanılan bir metoddur. Sunucu bu metodla gelen istek mesajının içeriğini aynen yanıt gövdesinde geri göndermelidir. 
        /// Bu yöntemle sunucu ile istemci arasında bir vekil sunucu varsa bu sunucunun ve yaptığı değişikliklerin tespiti mümkün olabilir.
        /// 4) PATCH: 
        /// Bu metod bir kaynağa istediğiniz küçük çaplı değişimi yapmanızı sağlar.
        /// 5) SEARCH: 
        /// Bir dizinin altındaki kaynakları sorgulamak için kullanılır.
        /// </summary>
    }
}
