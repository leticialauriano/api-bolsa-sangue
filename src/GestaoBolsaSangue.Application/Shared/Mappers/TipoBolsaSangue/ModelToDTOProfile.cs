using AutoMapper;

namespace GestaoBolsaSangue.Application.Shared.Mappers.TipoBolsaSangue
{
    public class ModelToDTOProfile : Profile
    {
        public ModelToDTOProfile()
        {
            CreateMap<Domain.Models.TipoBolsaSangue, DTOs.TipoBolsaSangue.TipoBolsaSangueDTO>().ReverseMap();
        }
    }
}
