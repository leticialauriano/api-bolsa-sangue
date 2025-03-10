namespace GestaoBolsaSangue.Domain.Validations
{
    public class SalvarBolsaSangueCommandValidation : BolsaSangueValidation
    {
        public SalvarBolsaSangueCommandValidation()
        {
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