using DAL;
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

    }
}