using BL;
using DAL;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace flags_app;

internal static class Program 
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new MainView());
        var kjl = new FlagService();
        //var eni = await kjl.GetAllFlagsAsync();


    }
}