using AutoMapper;
using GestaoBolsaSangue.Application.DTOs.TipoBolsaSangue;
using GestaoBolsaSangue.Application.Interfaces;
using GestaoBolsaSangue.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoBolsaSangue.Application.Services
{
    public class TipoBolsaSangueService : ITipoBolsaSangueService
    {
        private readonly ITipoBolsaSangueRepository _repository;
        private readonly IMapper _mapper;
        public TipoBolsaSangueService(ITipoBolsaSangueRepository tipoBolsaSangueRepository, IMapper mapper)
        {
            _repository = tipoBolsaSangueRepository;
            _mapper = mapper;
        }

        public async Task<IList<TipoBolsaSangueDTO>> Listar()
        {
            var responseRepository = await _repository.GetAll();
            return _mapper.Map<IList<TipoBolsaSangueDTO>>(responseRepository);
        }

        public async Task<TipoBolsaSangueDTO> Obter(Guid id)
        {
            var responseRepository = await _repository.GetById(id);
            return _mapper.Map<TipoBolsaSangueDTO>(responseRepository);
        }
    }
}
