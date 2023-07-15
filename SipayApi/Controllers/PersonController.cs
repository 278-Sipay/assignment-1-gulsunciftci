using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SipayApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static System.Net.WebRequestMethods;

namespace SipayApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase  //class bir class'ı extend almış 
    { // PersonController ControllerBase'i inherit etmiş.(miras almış). Otomatik olarak generate edilmiştir.
        public PersonController() //Constructor
        {

        }


        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                var messages = ModelState.ToList();
                return BadRequest("Post operation failed");
            }
            return Ok(person);
        }
    }

    ///<summary>
    ///Action Methodlar:
    ///Controller'lardan bahsederken benzer eylem gruplarını kapsayan sınıflar olduğundan bahsetmiştik. 
    ///Action metotları ise bir resource üzerinde gerçekleştirilebilecek eylemler olarak düşünebilirsiniz. Yapıları itibariyle normal metot tanımından bir farkları yoktur. 
    ///Http request'leri karşılayıp, servis içerisinde gerekli işlemler tamamlandıktan sonra http response'ları geri döndüren metotlardır.
    ///Eylemlere parametre geçmenin birden fazla yolu vardır.En çok kullanılan 3 yöntem FromBody, FromQuery ve FromRoute attribute'leri kullanılarak yapılanlardır.
    ///1) FromBody: Http request inin body'si içerisinde gönderilen parametreleri okumak için kullanılır.
    ///2) FromQuery: Url içerisine gömülen parametreleri okumak için kullanılan attribute dur.
    ///3) FromRoute: Endpoint url'i içerisinde gönderilen parametreleri okumak için kullanılır. Yaygın olarak resource'a ait id bilgisi okurken kullanılır. 
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
    ///1) SAFE Metotlar:
    ///* GET – HEAD – OPTIONS : Sunucu “state” tarafında değişiklik oluşturmazlar. “Read-only” yapısındadırlar.
    ///2) IDEMPOTENT Metotlar:
    ///* GET – HEAD - OPTIONS – DELETE – PUT – TRACE : Tekrar durumunda sunucu state yapısında herhangi bir yan etki bırakmazlar.Safe metodlar, idempotent'tır.
    ///Endpoint (Sorgu Adresi):
    ///* REST API kullanımında gönderilen istek ile verilen cevap için belirlenen buluşma noktasıdır.
    /// </summary>



}
