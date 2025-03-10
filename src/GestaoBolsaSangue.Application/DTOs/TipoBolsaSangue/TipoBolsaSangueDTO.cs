using System;

namespace GestaoBolsaSangue.Application.DTOs.TipoBolsaSangue
{
    [Serializable]
    public class TipoBolsaSangueDTO
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }
    }
}
