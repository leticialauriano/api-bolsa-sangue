using FluentValidation;
using System;
using static core.Messages.Validators.Messages;
using static core.Util.Validator.CustomValidators;

namespace GestaoBolsaSangue.Domain.Validations
{
    public abstract class BolsaSangueValidation : core.Types.AbstractValidator<Models.BolsaSangue>
    {
        protected void ValidarIdAnimal()
        {
            RuleFor(c => c.Animal.Id)
                .NotEqual(Guid.Empty).WithMessage(FluentValidator.CampoInvalido);
        }
        protected void ValidarIdTipo()
        {
            RuleFor(c => c.Tipo.Id)
                .NotEqual(Guid.Empty).WithMessage(FluentValidator.CampoInvalido);
        }
        protected void ValidarQuantidade()
        {
            RuleFor(c => c.Quantidade)
                .NotNull().WithMessage(FluentValidator.CampoObrigatorio)
                .GreaterThan(0).WithMessage(FluentValidator.CampoValorMaiorQue);
        }
        protected void ValidarDisponibilidadeImediata()
        {
            RuleFor(c => c.DisponibilidadeImediata)
                .NotNull().WithMessage(FluentValidator.CampoObrigatorio);
        }
        protected void ValidarDataColeta()
        {
            RuleFor(c => c.DataColeta)
                .NotNull().WithMessage(FluentValidator.CampoObrigatorio)
                .DataValidaRule().WithMessage(FluentValidator.CampoInvalido);
        }
        protected void ValidarDataValidade()
        {
            RuleFor(c => c.DataValidade)
                .NotNull().WithMessage(FluentValidator.CampoObrigatorio)
                .DataValidaRule().WithMessage(FluentValidator.CampoInvalido)
                .GreaterThan(c => c.DataColeta).WithMessage(FluentValidator.CampoValorMaiorQue);
        }

        protected void ValidarVolume()
        {
            RuleFor(c => c.Volume)
                .NotNull().WithMessage(FluentValidator.CampoObrigatorio)
                .GreaterThan(0).WithMessage(FluentValidator.CampoValorMaiorQue);
        }

        protected void ValidarInformacoesAdicionais()
        {
            RuleFor(c => c.InformacoesAdicionais)
                .Length(3, 300).WithMessage(FluentValidator.CampoTamanhoMaiorQueMenorQue)
                .When(w => !string.IsNullOrWhiteSpace(w.InformacoesAdicionais));
        }
    }
}
