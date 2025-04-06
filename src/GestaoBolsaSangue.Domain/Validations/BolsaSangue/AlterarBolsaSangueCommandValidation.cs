namespace GestaoBolsaSangue.Domain.Validations
{
    public class AlterarBolsaSangueCommandValidation : BolsaSangueValidation
    {
        public AlterarBolsaSangueCommandValidation()
        {
            ValidarId();
            ValidarIdAnimal();
            ValidarIdTipo();
            ValidarQuantidade();
            ValidarDisponibilidadeImediata();
            ValidarDataColeta();
            ValidarDataValidade();
            ValidarVolume();
            ValidarInformacoesAdicionais();
        }
    }
}