using AutoMapper;
using GestaoBolsaSangue.Application.Interfaces;
using GestaoBolsaSangue.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoBolsaSangue.Application.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _repository;
        private readonly IMapper _mapper;
        public AnimalService(IAnimalRepository tipoBolsaSangueRepository, IMapper mapper)
        {
            _repository = tipoBolsaSangueRepository;
            _mapper = mapper;
        }

        public async Task<IList<DTOs.Animal.AnimalDTO>> Listar()
        {
            var responseRepository = await _repository.GetAll();
            return _mapper.Map<IList<DTOs.Animal.AnimalDTO>>(responseRepository);
        }

        public async Task<DTOs.Animal.AnimalDTO> Obter(Guid id)
        {
            var responseRepository = await _repository.GetById(id);
            return _mapper.Map<DTOs.Animal.AnimalDTO>(responseRepository);
        }
    }
}
