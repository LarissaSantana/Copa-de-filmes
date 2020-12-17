using CopaDeFilmes.Application.Interfaces;
using CopaDeFilmes.Application.ViewModels;
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

        public FilmeController(IFilmeAppService filmeAppService)
        {
            _filmeAppService = filmeAppService;
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
            var vencedores = _filmeAppService.GerarCampeonato(filmes);
            return Ok(vencedores);
        }

    }
}
