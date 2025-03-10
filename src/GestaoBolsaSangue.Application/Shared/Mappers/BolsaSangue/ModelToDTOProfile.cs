using AutoMapper;

namespace GestaoBolsaSangue.Application.Shared.Mappers.BolsaSangue
{
    public class ModelToDTOProfile : Profile
    {
        public ModelToDTOProfile()
        {
            CreateMap<DTOs.Salvar.SalvarBolsaSangueDTO, Domain.Models.BolsaSangue>()
                .ForPath(d => d.Animal.Id, opt => opt.MapFrom(s => s.IdAnimal))
                .ForPath(d => d.Tipo.Id, opt => opt.MapFrom(s => s.IdTipoBolsa))
                .ForPath(d => d.Proprietario.Id, opt => opt.MapFrom(s => s.IdProprietario))
                .ForPath(d => d.Localizacao.Id, opt => opt.MapFrom(s => s.IdLocalizacao));

            CreateMap<Domain.Models.Animal, DTOs.BolsaSangue.Listar.AnimalDTO>().ReverseMap();
            CreateMap<Domain.Models.Proprietario, DTOs.BolsaSangue.Listar.ProprietarioDTO>().ReverseMap();
            CreateMap<Domain.Models.Localizacao, DTOs.BolsaSangue.Listar.LocalizacaoDTO>().ReverseMap();
            CreateMap<Domain.Models.TipoBolsaSangue, DTOs.BolsaSangue.Listar.TipoBolsaSangueDTO>().ReverseMap();
            CreateMap<Domain.Models.BolsaSangue, DTOs.Listar.ListarBolsaSangueDTO>().ReverseMap();
        }
    }
}
