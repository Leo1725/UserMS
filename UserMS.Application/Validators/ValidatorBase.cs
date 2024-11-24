using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMs.Infrastructure.Exceptions;

namespace UserMS.Application.Validators
{
    public class ValidatorBase<T> : AbstractValidator<T>
    {
        public virtual async Task<bool> ValidateRequest(T request)
        {
            var result = await ValidateAsync(request);
            if (!result.IsValid)
            {
                throw new ValidatorException(result.Errors);
            }

            return result.IsValid;
        }
    }
}
