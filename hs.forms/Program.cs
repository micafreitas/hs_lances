using hs.IoC;
using hs.service.Interfaces;
using Hs;
using Microsoft.Extensions.DependencyInjection;

namespace hs.forms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();

            NativeInjectorBootStrapper.RegisterServices(services);

            var serviceProvider = services.BuildServiceProvider();
            
            ApplicationConfiguration.Initialize();
            Application.Run(new Principal(serviceProvider));
        }
    }
}