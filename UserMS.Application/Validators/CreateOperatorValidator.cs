using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMS.Commons.Dtos.Request;

namespace UserMS.Application.Validators
{
    public class CreateOperatorValidator : ValidatorBase<CreateOperatorDto>
    {
        public CreateOperatorValidator()
        {
            RuleFor(s => s.Name).NotNull().WithMessage("No puede ser nulo").WithErrorCode("654");
            RuleFor(s => s.Age).NotNull().WithMessage("No puede ser nulo").WithErrorCode("654");
            RuleFor(s => s.State).NotNull().WithMessage("No puede ser nulo").WithErrorCode("654");
        }
    }
}
