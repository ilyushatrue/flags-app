using AutoMapper;
using DAL.AutoMapperConfig;

namespace DAL.Repositories.Base;

public class BaseRepository
{
    internal Context Context { get; } 
    internal Mapper Mapper { get; } 

    public BaseRepository()
    {
        Context = Context.Initialize();
        Mapper = AutoMapperConfiguration.Initialize().Mapper; 
    }
}
