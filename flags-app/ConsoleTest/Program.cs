// See https://aka.ms/new-console-template for more information
using BL;

Console.WriteLine("Hello, World!");
var k = new FlagService();
var isdaf = await k.GetAllFlagsAsync();
isdaf.ToList().ForEach(x => Console.WriteLine(x));  
