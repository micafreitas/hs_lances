using hs.db;
using hs.db.Interfaces;
using hs.service;
using hs.service.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace hs.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IContextoDb, ContextoDb>();
            services.AddSingleton<IParametroService, ParametroService>();

            services.AddScoped<IAvisoLanceService, AvisoLanceService>();
            services.AddScoped<IChaveAppService, ChaveAppService>();
            services.AddScoped<ILanceService, LanceService>();
            services.AddScoped<IContaAcessoService, ContaAcessoService>();
            services.AddScoped<IPortalHsService, PortalHsService>();
            services.AddScoped<IRegistroLanceService, RegistroLanceService>();
            services.AddScoped<ILanceService, LanceService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<ICotaConsorcioService, CotaConsorcioService>();
        }
    }
}