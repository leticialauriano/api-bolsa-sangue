using FluentValidation.Results;
using MediatR;
using System;

namespace core.Types
{
    public class Command : IRequest<ValidationResult>
    {
        public DateTime DateTime { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            DateTime = DateTime.Now;
            ValidationResult = new ValidationResult();
        }

        public virtual bool IsValid()
        {
            return ValidationResult.IsValid;
        }
    }
}