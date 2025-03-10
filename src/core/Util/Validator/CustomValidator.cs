using FluentValidation;
using FluentValidation.Validators;
using System;
using System.ComponentModel.DataAnnotations;

namespace core.Util.Validator
{
    public static class CustomValidators
    {
        public static IRuleBuilderOptions<T, string> MatchPhoneNumberRule<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new RegularExpressionValidator(@"((?:[0-9]\-?){6,14}[0-9]$)|((?:[0-9]\x20?){6,14}[0-9]$)"));
        }

        public static IRuleBuilderOptions<T, string> EmailAddressRule<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new RegularExpressionValidator(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"));
        }

        public static IRuleBuilderOptions<T, string> CNPJRule<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new RegularExpressionValidator(@"[0-9]{2}\.?[0-9]{3}\.?[0-9]{3}\/?[0-9]{4}\-?[0-9]{2}"));
        }

        public static IRuleBuilderOptions<T, DateTime> DataValidaRule<T>(this IRuleBuilder<T, DateTime> ruleBuilder)
        {
            return ruleBuilder.NotNull().NotEqual(default(DateTime));
        }

        public static IRuleBuilderOptions<T, Guid> IdRule<T>(this IRuleBuilder<T, Guid> ruleBuilder)
        {
            return ruleBuilder.NotEqual(Guid.Empty)
                .WithName("Id")
                .WithMessage(Messages.Validators.Messages.FluentValidator.CampoInvalido);
        }
    }
}