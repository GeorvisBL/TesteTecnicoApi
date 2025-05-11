using Microsoft.AspNetCore.Mvc;
using TesteTecnicoApi.Services.Interfaces;

namespace TesteTecnicoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaturaStatusController : ControllerBase
    {

        private readonly IFaturaStatusServices _faturaStatusServices;
        public FaturaStatusController(IFaturaStatusServices faturaStatusServices)
        {
            _faturaStatusServices = faturaStatusServices;
        }



        [HttpGet("BuscarFaturaStatus")]
        public async Task<IActionResult> BuscarFaturaStatus()
        {
            var retornoFaturaStatus = await _faturaStatusServices.GetListaFaturaStatus();

            if (retornoFaturaStatus.Count() <= 0) return BadRequest("Não existem registros na base de dados!");

            return Ok(retornoFaturaStatus);
        }

    }
}
