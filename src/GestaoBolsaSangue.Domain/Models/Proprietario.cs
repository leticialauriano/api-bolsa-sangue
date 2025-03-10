using core.Types;
using System;

namespace GestaoBolsaSangue.Domain.Models
{
    public class Proprietario : Entity
    {
        public Proprietario(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        protected Proprietario()
        {
        }

        public string Nome { get; private set; }
    }
}
