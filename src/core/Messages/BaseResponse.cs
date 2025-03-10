using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace core.Messages
{
    [DataContract]
    [Serializable]
    public class BaseResponse<T>
    {
        public BaseResponse()
        {
            this.Valido = true;
        }

        [DataMember(Name = "valido")]
        public bool Valido { get; set; }

        [DataMember(Name = "resultados")]
        public T Resultados { get; set; }

        [DataMember(Name = "mensagens")]
        public List<string> Mensagens { get; set; }

        public void AdicionarMensagemErro(string mensagemErro)
        {
            if (Mensagens == null)
                Mensagens = new List<string>();

            Mensagens.Add(mensagemErro);
            Valido = false;
        }

        public void AdicionarMensagensErros(ValidationResult result)
        {
            if (Mensagens == null)
                Mensagens = new List<string>();

            Mensagens.AddRange(result.Errors.Select(s => s.ErrorMessage));
            Valido = false;
        }

        public bool PossuiResultados()
        {
            return this.Resultados != null;
        }
    }
}