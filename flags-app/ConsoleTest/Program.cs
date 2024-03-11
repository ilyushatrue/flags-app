using BL;
using BL.Services;

var flagService = new FlagService();
var catalogService = new CatalogService();
var countryService = new CountryService();
var flagAreaService= new FlagAreaService();
var flagPatternService= new FlagPatternService();

var countryId = await countryService.CreateCountryAsync(new()
{
    CapitalName = "Москва",
    Name =  "Россия",
});
var color = await catalogService.GetColorAsync("black");
if (color == null) return;
var flagId = await flagService.CreateFlagAsync(new()
{
    Name = "Российский флаг",
    CountryId = countryId,
});

var flagArea = await flagAreaService.CreateFlagAreaAsync(new() 
{ 
    ColorId = color.Id,
    FlagId = flagId,
});

var isdaf = await flagService.GetAllFlagsAsync();
isdaf.ToList().ForEach(Console.WriteLine);
