using core.Types;
using GestaoBolsaSangue.Domain.Models;
using GestaoBolsaSangue.Domain.Validations;

namespace GestaoBolsaSangue.Domain.Commands
{
    public class AlterarBolsaSangueCommand : Command
    {
        public AlterarBolsaSangueCommand(BolsaSangue BolsaSangue)
        {
            this.BolsaSangue = BolsaSangue;
        }

        public BolsaSangue BolsaSangue { get; protected set; }

        public override bool IsValid()
        {
            ValidationResult = new AlterarBolsaSangueCommandValidation().Validate(BolsaSangue);
            return ValidationResult.IsValid;
        }
    }
}
