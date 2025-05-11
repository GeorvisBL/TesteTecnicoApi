using Microsoft.AspNetCore.Mvc;
using TesteTecnicoApi.Services.Interfaces;

namespace TesteTecnicoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoServicosController : ControllerBase
    {

        private readonly ITipoServicoServices _tipoServicoServices;
        public TipoServicosController(ITipoServicoServices tipoServicoServices)
        {
            _tipoServicoServices = tipoServicoServices;
        }


        [HttpGet("BuscarTipoServicos")]
        public async Task<IActionResult> BuscarFaturas()
        {
            var retornoTipoServicos = await _tipoServicoServices.GetListaTipoServicos();

            if (retornoTipoServicos.Count() <= 0) return BadRequest("Não existem registros na base de dados!");

            return Ok(retornoTipoServicos);
        }

    }
}
