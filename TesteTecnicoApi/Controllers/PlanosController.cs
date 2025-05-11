using Microsoft.AspNetCore.Mvc;
using TesteTecnicoApi.Dto.Plano;
using TesteTecnicoApi.Models;
using TesteTecnicoApi.Services.Interfaces;

namespace TesteTecnicoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanosController : ControllerBase
    {

        private readonly IPlanoServices _planoServices;
        public PlanosController(IPlanoServices planoServices)
        {
            _planoServices = planoServices;
        }



        [HttpGet("BuscarPlanos")]
        public async Task<IActionResult> BuscarPlanos()
        {
            var retornoPlanos = await _planoServices.GetListaPlanos();

            if (retornoPlanos.Count() <= 0) return BadRequest("Não existem registros na base de dados!");

            return Ok(retornoPlanos);
        }


    }
}
