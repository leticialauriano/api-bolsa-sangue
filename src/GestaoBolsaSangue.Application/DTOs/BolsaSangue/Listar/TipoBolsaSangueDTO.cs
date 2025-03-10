using System;

namespace GestaoBolsaSangue.Application.DTOs.BolsaSangue.Listar
{
    [Serializable]
    public class TipoBolsaSangueDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}
