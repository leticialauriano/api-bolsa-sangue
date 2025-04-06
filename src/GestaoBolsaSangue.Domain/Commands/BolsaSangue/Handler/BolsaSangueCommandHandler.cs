using core.Types;
using FluentValidation.Results;
using MediatR;
using GestaoBolsaSangue.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using static core.Messages.Validators.Messages;
using GestaoBolsaSangue.Domain.Models;
using System.Linq;

namespace GestaoBolsaSangue.Domain.Commands.Handler
{
    public class BolsaSangueCommandHandler : CommandHandler,
        IRequestHandler<SalvarBolsaSangueCommand, ValidationResult>,
        IRequestHandler<AlterarBolsaSangueCommand, ValidationResult>
    {
        private readonly IBolsaSangueRepository _repository;
        private readonly ITipoBolsaSangueRepository _tipoBolsaSangueRepository;
        private readonly IAnimalRepository _animalRepository;
        private readonly IProprietarioRepository _proprietarioRepository;

        public BolsaSangueCommandHandler(IBolsaSangueRepository bolsaSangueRepository, ITipoBolsaSangueRepository tipoBolsaSangueRepository, IAnimalRepository animalRepository, IProprietarioRepository proprietarioRepository)
        {
            _repository = bolsaSangueRepository;
            _tipoBolsaSangueRepository = tipoBolsaSangueRepository;
            _animalRepository = animalRepository;
            _proprietarioRepository = proprietarioRepository;
        }

        public async Task<ValidationResult> Handle(SalvarBolsaSangueCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
                return command.ValidationResult;

            var animalExists = await _animalRepository.GetById(command.BolsaSangue.Animal.Id);
            if (animalExists == null)
            {
                AddError(string.Format(Erros.EntidadeNaoEncontrado, "Animal"));
                return Notification;
            }

            var tipoBolsaExists = await _tipoBolsaSangueRepository.GetById(command.BolsaSangue.Tipo.Id);
            if (tipoBolsaExists == null)
            {
                AddError(string.Format(Erros.EntidadeNaoEncontrado, "Tipo"));
                return Notification;
            }

            var proprietarioExists = await _proprietarioRepository.GetById(command.BolsaSangue.Proprietario.Id);
            if (proprietarioExists == null)
            {
                AddError(string.Format(Erros.EntidadeNaoEncontrado, "Proprietario"));
                return Notification;
            }

            var enderecoExists = proprietarioExists.Enderecos.Where(w => w.Id == command.BolsaSangue.Localizacao.Id).FirstOrDefault();
            if (enderecoExists == null)
            {
                AddError(string.Format(Erros.EntidadeNaoEncontrado, "Endereco"));
                return Notification;
            }

            var bolsaSangue = new BolsaSangue(command.BolsaSangue.Id, command.BolsaSangue.Quantidade, command.BolsaSangue.DisponibilidadeImediata, command.BolsaSangue.DataColeta, command.BolsaSangue.DataValidade, command.BolsaSangue.Volume, command.BolsaSangue.InformacoesAdicionais);
            bolsaSangue.DefinirAnimal(animalExists);
            bolsaSangue.DefinirTipoSanguineo(tipoBolsaExists);
            bolsaSangue.IdentificarProprietario(new Proprietario(proprietarioExists.Id, proprietarioExists.Nome));
            bolsaSangue.DefinirLocalizacao(new Localizacao(enderecoExists.Id, enderecoExists.Nome, enderecoExists.Longitude, enderecoExists.Latitude));

            _repository.Add(bolsaSangue);

            return await Commit(_repository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AlterarBolsaSangueCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
                return command.ValidationResult;

            var animalExists = await _animalRepository.GetById(command.BolsaSangue.Animal.Id);
            if (animalExists == null)
            {
                AddError(string.Format(Erros.EntidadeNaoEncontrado, "Animal"));
                return Notification;
            }

            var tipoBolsaExists = await _tipoBolsaSangueRepository.GetById(command.BolsaSangue.Tipo.Id);
            if (tipoBolsaExists == null)
            {
                AddError(string.Format(Erros.EntidadeNaoEncontrado, "Tipo"));
                return Notification;
            }

            var proprietarioExists = await _proprietarioRepository.GetById(command.BolsaSangue.Proprietario.Id);
            if (proprietarioExists == null)
            {
                AddError(string.Format(Erros.EntidadeNaoEncontrado, "Proprietario"));
                return Notification;
            }

            var enderecoExists = proprietarioExists.Enderecos.Where(w => w.Id == command.BolsaSangue.Localizacao.Id).FirstOrDefault();
            if (enderecoExists == null)
            {
                AddError(string.Format(Erros.EntidadeNaoEncontrado, "Endereco"));
                return Notification;
            }

            var bolsaSangue = new BolsaSangue(command.BolsaSangue.Id, command.BolsaSangue.Quantidade, command.BolsaSangue.DisponibilidadeImediata, command.BolsaSangue.DataColeta, command.BolsaSangue.DataValidade, command.BolsaSangue.Volume, command.BolsaSangue.InformacoesAdicionais);
            bolsaSangue.DefinirAnimal(animalExists);
            bolsaSangue.DefinirTipoSanguineo(tipoBolsaExists);
            bolsaSangue.IdentificarProprietario(new Proprietario(proprietarioExists.Id, proprietarioExists.Nome));
            bolsaSangue.DefinirLocalizacao(new Localizacao(enderecoExists.Id, enderecoExists.Nome, enderecoExists.Longitude, enderecoExists.Latitude));

            _repository.Update(bolsaSangue);

            return await Commit(_repository.UnitOfWork);
        }

    }
}