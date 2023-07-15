using FluentValidation;
using System;

namespace SipayApi.Models.Validators
{
    public class PersonValidator : AbstractValidator<Person> //Hangi sınıfın validator'ı olduğunu göstermek için o sınıfın AbstractValidator'ının inherit aldım 
    {
        public PersonValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Name cannot be empty");
            RuleFor(x => x.Name).MinimumLength(5).MaximumLength(100).WithMessage("Name length can be at least 5 and up to 100"); ;


            RuleFor(x => x.LastName).NotEmpty().NotNull().WithMessage("LastName cannot be empty");
            RuleFor(x => x.LastName).MinimumLength(5).MaximumLength(100).WithMessage("Lastname length can be at least 5 and up to 100");

            RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone cannot be empty");


            RuleFor(x => x.AccessLevel).NotEmpty().NotNull().InclusiveBetween(1,5).WithMessage("AccessLevel cannot be empty");
            RuleFor(x => x.AccessLevel).InclusiveBetween(1, 5).WithMessage("AccessLevel should be between 1 and 5");


            RuleFor(x => x.Salary).NotEmpty().NotNull().WithMessage("Salary cannot be empty");
            RuleFor(x => x.Salary).InclusiveBetween(5000, 50000).WithMessage("Salary should be between 5000 and 50000");


        }
    }
}
