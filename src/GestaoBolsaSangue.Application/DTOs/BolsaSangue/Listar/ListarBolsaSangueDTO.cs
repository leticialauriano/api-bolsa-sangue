using GestaoBolsaSangue.Application.DTOs.BolsaSangue.Listar;
using System;

namespace GestaoBolsaSangue.Application.DTOs.Listar
{
    [Serializable]
    public class ListarBolsaSangueDTO
    {
        public Guid Id { get; set; }
        public AnimalDTO Animal { get; set; }
        public ProprietarioDTO Proprietario { get; set; }
        public LocalizacaoDTO Localizacao { get; set; }
        public TipoBolsaSangueDTO Tipo { get; set; }
        public int Quantidade { get; set; }
        public bool DisponibilidadeImediata { get; set; }
        public DateTime DataColeta { get; set; }
        public DateTime DataValidade { get; set; }
        public double Volume { get; set; }
        public string InformacoesAdicionais { get; set; }
    }
}