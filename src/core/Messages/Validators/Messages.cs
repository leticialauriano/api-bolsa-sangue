namespace core.Messages.Validators
{
    public sealed class Messages
    {
        private Messages() { }
        public static class Erros
        {
            public const string RegistroCnpjExistente = "O CNPJ {0} é inválido. Por favor, insira outro CNPJ válido.";
            public const string RegistroEmailExistente = "O e-mail inserido já pertence a outro cadastro.";
            public const string RegistroNaoEncontrado = "Registro não encontrado.";
            public const string EntidadeNaoEncontrado = "Registro de {0} não encontrado.";
            public const string Exception = "Ocorreu um erro inesperado durante o processamento.";
            public const string CommitError = "Ocorreu um erro para salvar as informações.";
        }

        public static class FluentValidator
        {
            public const string CampoDecimalEscalaInvalida = "O campo {PropertyName} é inválido, por favor insira uma informação válida.";
            public const string CampoInvalido = "O campo {PropertyName} é inválido, por favor insira uma informação válida.";
            public const string CampoTamanhoMaiorQueMenorQue = "O campo {PropertyName} deve ter entre {MinLength} e {MaxLength} caracteres.";
            public const string CampoValorMaiorQue = "O campo {PropertyName} deve ser maior que {ComparisonValue}.";
            public const string CampoObrigatorio = "O campo {PropertyName} é obrigatório.";
            public const string CampoObrigatorioUmaLetraMaiuscula = "O campo {PropertyName} deve conter pelo menos uma letra maiúscula.";
            public const string CampoObrigatorioUmaLetraMinuscula = "O campo {PropertyName} deve conter pelo menos uma letra minúscula.";
            public const string CampoObrigatorioUmDigito = "O campo {PropertyName} deve conter pelo menos pelo menos um dígito.";
            public const string CampoObrigatorioUmCaracterEspecial = "O campo {PropertyName} deve conter pelo menos  um caracter especial.";
            public const string CampoValorMenorQue = "O campo {PropertyName} não pode ser maior que {ComparisonValue}.";
            public const string CampoExcedeLimiteDigitos = "O campo {PropertyName} excedeu o maximo de digitos permitidos.";
        }
    }
}