using CopaDeFilmes.Application.Interfaces;
using CopaDeFilmes.Application.Services;
using CopaDeFilmes.Data.Repositories;
using CopaDeFilmes.Domain.Core.Notifications;
using CopaDeFilmes.Domain.Repositories;
using CopaDeFilmes.Domain.Service;
using Microsoft.Extensions.DependencyInjection;

namespace CopaDeFilmes.API
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //TODO: analisar se vai ser AddScoped mesmo e organizar melhor a DI
            //Colocar a DI numa crosscutting e remover a referencia de Data daqui do projeo API
            services.AddScoped<IFilmeRepository, FilmeRepository>();
            services.AddScoped<IFilmeAppService, FilmeAppService>();
            services.AddScoped<IFilmeService, FilmeService>();
            services.AddScoped<INotificationContext<Notification>, NotificationContext>();
        }
    }
}
