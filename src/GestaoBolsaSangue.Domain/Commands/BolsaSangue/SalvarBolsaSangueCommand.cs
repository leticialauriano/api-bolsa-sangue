using core.Types;
using GestaoBolsaSangue.Domain.Models;
using GestaoBolsaSangue.Domain.Validations;

namespace GestaoBolsaSangue.Domain.Commands
{
    public class SalvarBolsaSangueCommand : Command
    {
        public SalvarBolsaSangueCommand(BolsaSangue bolsaSangue)
        {
            bolsaSangue.AddNewId();
            BolsaSangue = bolsaSangue;
        }

        public BolsaSangue BolsaSangue { get; protected set; }

        public override bool IsValid()
        {
            ValidationResult = new SalvarBolsaSangueCommandValidation().Validate(BolsaSangue);
            return ValidationResult.IsValid;
        }
    }
}
