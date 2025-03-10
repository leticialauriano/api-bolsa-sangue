using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace GestaoBolsaSangue.Application.DTOs.Salvar
{
    [Serializable]
    [DataContract]
    public class SalvarBolsaSangueDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DataMember(Name = "IdProprietario")]
        public Guid IdProprietario { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DataMember(Name = "IdLocalizacao")]
        public Guid IdLocalizacao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DataMember(Name = "IdAnimal")]
        public Guid IdAnimal { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DataMember(Name = "IdTipoBolsa")]
        public Guid IdTipoBolsa { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DataMember(Name = "Quantidade")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DataMember(Name = "DisponibilidadeImediata")]
        public bool DisponibilidadeImediata { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DataMember(Name = "DataColeta")]
        public DateTime DataColeta { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DataMember(Name = "DataValidade")]
        public DateTime DataValidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DataMember(Name = "Volume")]
        public double Volume { get; set; }

        [DataMember(Name = "InformacoesAdicionais")]
        public string InformacoesAdicionais { get; set; }
    }
}