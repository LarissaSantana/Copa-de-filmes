using CopaDeFilmes.Application.Interfaces;
using CopaDeFilmes.Application.ViewModels;
using CopaDeFilmes.Domain.Core.Notifications;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaDeFilmes.API.Controllers
{
    //TODO: Implementar versionamento da API e documentação swagger
    [Route("api/filme")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeAppService _filmeAppService;
        private readonly INotificationContext _notification;

        public FilmeController(IFilmeAppService filmeAppService, INotificationContext notification)
        {
            _filmeAppService = filmeAppService;
            _notification = notification;
        }

        [HttpGet]
        public async Task<IActionResult> ObterFilmes()
        {
            var filmes = await _filmeAppService.ObterTodosOsFilmes();
            return Ok(filmes);
        }

        [HttpPost]
        public IActionResult GerarCampeonato([FromBody] List<FilmeViewModel> filmes)
        {
            var vencedores = _filmeAppService.ProcessarCampeonato(filmes);
            return Ok(vencedores);
        }
    }
}
