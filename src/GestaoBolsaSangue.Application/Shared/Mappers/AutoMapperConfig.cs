using AutoMapper;

namespace GestaoBolsaSangue.Application.Shared.Mappers
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new TipoBolsaSangue.ModelToDTOProfile());
                cfg.AddProfile(new Animal.ModelToDTOProfile());
                cfg.AddProfile(new BolsaSangue.ModelToDTOProfile());
            });
        }
    }
}