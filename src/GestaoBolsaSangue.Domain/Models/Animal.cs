using core.Types;
using System;

namespace GestaoBolsaSangue.Domain.Models
{
    public class Animal : Entity
    {
        protected Animal()
        {
        }

        public string Nome { get; private set; }
    }
}
