using CopaDeFilmes.Application.Interfaces;
using CopaDeFilmes.Application.ViewModels;
using CopaDeFilmes.Domain.Core.Notifications;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaDeFilmes.API.Controllers
{
    //TODO: Implementar versionamento da API e documentação swagger
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
        public IActionResult GerarCampeonato([FromBody] List<FilmeViewModel> filmes)
        {
            var vencedores = _filmeAppService.ProcessarCampeonato(filmes);
            return GetResponse(vencedores);
        }
    }
}
