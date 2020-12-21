using CopaDeFilmes.Application.Interfaces;
using CopaDeFilmes.Application.ViewModels;
using CopaDeFilmes.Domain.Core.Notifications;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CopaDeFilmes.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class FilmeController : BaseController
    {
        private readonly IFilmeAppService _filmeAppService;

        public FilmeController(IFilmeAppService filmeAppService,
                               INotificationContext<Notification> notification) : base(notification)
        {
            _filmeAppService = filmeAppService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterFilmes()
        {
            var filmes = await _filmeAppService.ObterTodosOsFilmes();
            return GetResponse(filmes);
        }

        [HttpPost]
        public IActionResult GerarCampeonato([FromBody] FilmesViewModel filmesViewModel)
        {
            var campeonato = _filmeAppService.ProcessarCampeonato(filmesViewModel.filmes);
            return GetResponse(campeonato);
        }
    }
}
