using CopaDeFilmes.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CopaDeFilmes.API.Controllers
{
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
    }
}
