﻿using DAL.DTOs;
using DAL.Models;
using DAL.Repositories.Base;

namespace DAL.Repositories;

public class CountryRepository : BaseRepository
{
    public async Task<int> CreateCountryAsync(CountryDto dto) 
    {
        var entity = Mapper.Map<Country>(dto);
        return await Context.InsertEntityAsync(entity);
    }
}
