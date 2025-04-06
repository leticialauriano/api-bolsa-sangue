using System;
using System.ComponentModel.DataAnnotations;

namespace GestaoBolsaSangue.Application.DTOs.Alterar
{
    [Serializable]
    public class AlterarBolsaSangueDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Guid IdProprietario { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Guid IdLocalizacao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Guid IdAnimal { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Guid IdTipoBolsa { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public bool DisponibilidadeImediata { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public DateTime DataColeta { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public DateTime DataValidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public double Volume { get; set; }

        public string InformacoesAdicionais { get; set; }
    }
}