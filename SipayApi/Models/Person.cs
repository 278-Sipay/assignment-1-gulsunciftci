using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SipayApi.Models
{
    public class Person
    {
        

        public string Name { get; set; }

    
        public string LastName { get; set; }

       
        public DateTime Phone { get; set; }

       
        public int AccessLevel { get; set; }


        public decimal Salary { get; set; }

    }
}
