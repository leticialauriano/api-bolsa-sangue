using System;
using System.Collections.Generic;

namespace GestaoBolsaSangue.Domain.Shared.Model
{
    [Serializable]
    public class Proprietario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public List<Endereco> Enderecos { get; set; }
    }
}
