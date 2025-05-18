using core.Types;
using FluentValidation.Results;
using GestaoBolsaSangue.Domain.Validations;
using System;

namespace GestaoBolsaSangue.Domain.Commands
{
    public class DeletarBolsaSangueCommand : Command
    {
        public DeletarBolsaSangueCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; protected set; }

        public override bool IsValid()
        {
            ValidationResult = new DeletarBolsaSangueCommandValidation().Validate(Id);
            return ValidationResult.IsValid;
        }
    }
}