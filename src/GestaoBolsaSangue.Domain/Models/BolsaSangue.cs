using core.Types;
using GestaoBolsaSangue.Domain.Shared.Model;
using System;

namespace GestaoBolsaSangue.Domain.Models
{
    public class BolsaSangue : Entity
    {
        protected BolsaSangue()
        {
        }

        public BolsaSangue(Guid id, int quantidade, bool disponibilidadeImediata, DateTime dataColeta, DateTime dataValidade, double volume, string informacoesAdicionais)
        {
            Id = id;
            Quantidade = quantidade;
            DisponibilidadeImediata = disponibilidadeImediata;
            DataColeta = dataColeta;
            DataValidade = dataValidade;
            Volume = volume;
            InformacoesAdicionais = informacoesAdicionais;
        }

        internal void DefinirAnimal(Animal animal)
        {
            Animal = animal;
        }

        internal void DefinirTipoSanguineo(TipoBolsaSangue tipo)
        {
            Tipo = tipo;
        }

        internal void DefinirLocalizacao(Localizacao localizacao)
        {
            Localizacao = localizacao;
        }

        internal void IdentificarProprietario(Proprietario proprietario)
        {
            Proprietario = proprietario;
        }

        public Proprietario Proprietario { get; private set; }
        public Localizacao Localizacao { get; private set; }
        public Animal Animal { get; private set; }
        public TipoBolsaSangue Tipo { get; private set; }
        public int Quantidade { get; private set; }
        public bool DisponibilidadeImediata { get; private set; }
        public DateTime DataColeta { get; private set; }
        public DateTime DataValidade { get; private set; }
        public double Volume { get; private set; }
        public string InformacoesAdicionais { get; private set; }
    }
}