using AutoMapper;
using System.Collections.Generic;

namespace GestaoBolsaSangue.Application.Shared.Mappers.Animal
{
    public class ModelToDTOProfile : Profile
    {
        public ModelToDTOProfile()
        {
            CreateMap<Domain.Models.Animal, DTOs.Animal.AnimalDTO>().ReverseMap();
        }
    }
}
