using AutoMapper;
using DAL.DTOs;
using DAL.DTOs.Flags;
using DAL.DTOs.Flags.Attributes;
using DAL.Models;
using DAL.Models.Flags;
using DAL.Models.Flags.Attributes;

namespace DAL.AutoMapperConfig;

internal class AutoMapperConfiguration
{
    private readonly MapperConfiguration _configuration;
    private static AutoMapperConfiguration? _instance = null;
    private AutoMapperConfiguration() 
    {
        _configuration = new MapperConfiguration(config =>
        {
            config.CreateMap<Flag, FlagDto>();
            config.CreateMap<StripedFlag, StripedFlagDto>()
                .ForMember(dto=>dto.StripColor, exp => exp.MapFrom(entity => entity.StripColor.Name))
                .ForMember(dto=>dto.StripDirection, exp => exp.MapFrom(entity => entity.StripDirection.Name));
            config.CreateMap<FlagArea, FlagAreaDto>();
            config.CreateMap<CatalogItem, CatalogItemDto>();
            config.CreateMap<CatalogItemDto, CatalogItem>();
            config.CreateMap<Country, CountryDto>();
        });
        Mapper = new Mapper(_configuration);
    }

    public static AutoMapperConfiguration Initialize()
    {
        _instance ??= new AutoMapperConfiguration();
        return _instance;
    }

    public Mapper Mapper { get; }
}
