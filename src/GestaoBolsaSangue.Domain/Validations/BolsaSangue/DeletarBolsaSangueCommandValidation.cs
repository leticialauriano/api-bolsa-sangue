using core.Util.Validator;
using FluentValidation;
using System;

namespace GestaoBolsaSangue.Domain.Validations
{
    public class DeletarBolsaSangueCommandValidation : AbstractValidator<Guid>
    {
        public DeletarBolsaSangueCommandValidation()
        {
            ValidarId();
        }

        private void ValidarId()
        {
            RuleFor(id => id).IdRule();
        }
    }
}