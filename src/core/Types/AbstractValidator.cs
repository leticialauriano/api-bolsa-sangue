using core.Util.Validator;
using FluentValidation;
using System;

namespace core.Types
{
    public abstract class AbstractValidator<T> : FluentValidation.AbstractValidator<T> where T : Entity
    {
        protected AbstractValidator()
        {
        }

        protected void ValidarId()
        {
            RuleFor(c => c.Id).IdRule();
        }
    }
}
