using AutoMapper;
using core.Patterns.MediatR;
using FluentValidation.Results;
using GestaoBolsaSangue.Application.DTOs.Salvar;
using GestaoBolsaSangue.Application.Interfaces;
using GestaoBolsaSangue.Domain.Commands;
using GestaoBolsaSangue.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Listar = GestaoBolsaSangue.Application.DTOs.Listar;

namespace GestaoBolsaSangue.Application.Services
{
    public class BolsaSangueService : IBolsaSangueService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
        private readonly IBolsaSangueRepository _repository;
        public BolsaSangueService(IBolsaSangueRepository BolsaSangueRepository, IMapper mapper, IMediatorHandler mediator)
        {
            _repository = BolsaSangueRepository;
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task<ValidationResult> Salvar(SalvarBolsaSangueDTO request)
        {
            var bolsaSangueModel = _mapper.Map<Domain.Models.BolsaSangue>(request);
            var salvarCommand = new SalvarBolsaSangueCommand(bolsaSangueModel);

            return await _mediator.SendCommand(salvarCommand);
        }

        public async Task<IList<Listar.ListarBolsaSangueDTO>> Listar()
        {
            var responseRepository = await _repository.GetAll();
            return _mapper.Map<IList<Listar.ListarBolsaSangueDTO>>(responseRepository);
        }     

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
