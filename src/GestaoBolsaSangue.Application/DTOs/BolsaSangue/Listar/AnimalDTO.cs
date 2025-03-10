using System;

namespace GestaoBolsaSangue.Application.DTOs.BolsaSangue.Listar
{
    [Serializable]
    public class AnimalDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}
