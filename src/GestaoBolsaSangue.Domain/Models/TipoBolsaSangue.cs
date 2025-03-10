using core.Types;
using System;

namespace GestaoBolsaSangue.Domain.Models
{
    public class TipoBolsaSangue : Entity
    {
        protected TipoBolsaSangue()
        {
        }

        public string Nome { get; private set; }
    }
}
