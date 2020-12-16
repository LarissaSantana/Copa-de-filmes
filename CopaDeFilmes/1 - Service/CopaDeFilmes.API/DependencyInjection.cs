using CopaDeFilmes.Application.Interfaces;
using CopaDeFilmes.Application.Services;
using CopaDeFilmes.Data.Repositories;
using CopaDeFilmes.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CopaDeFilmes.API
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //TODO: analisar se vai ser AddScoped mesmo e organizar melhor a DI
            services.AddScoped<IFilmeRepository, FilmeRepository>();
            services.AddScoped<IFilmeAppService, FilmeAppService>();

        }
    }
}
