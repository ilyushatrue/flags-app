using BL;
using DAL.DTOs.Flags;
using DAL.DTOs.Flags.Attributes;

var flagService = new FlagService();
var catalogService = new CatalogService();
var countryService = new CountryService();

var color = await catalogService.GetColorAsync("black");
if (color == null) return;
//var area = new FlagAreaDto()
//{
//    ColorId = color,
//};

var sadf = await flagService.CreateFlagAsync(new FlagDto()
{
    Area = new FlagAreaDto()
    {

    }
});
var isdaf = await flagService.GetAllFlagsAsync();
isdaf.ToList().ForEach(Console.WriteLine);
