using Microsoft.AspNetCore.Mvc;
using TesteTecnicoApi.Dto.Fatura;
using TesteTecnicoApi.Services.Interfaces;

namespace TesteTecnicoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaturasController : ControllerBase
    {

        private readonly IFaturaServices _faturaServices;
        public FaturasController(IFaturaServices faturaServices)
        {
            _faturaServices = faturaServices;
        }


        [HttpGet("BuscarFaturas")]
        public async Task<IActionResult> BuscarFaturas()
        {
            var retornoFaturas = await _faturaServices.GetListaFaturas();

            if (retornoFaturas.Count() <= 0) return BadRequest("Não existem registros na base de dados!");

            return Ok(retornoFaturas);
        }
                


        [HttpGet("BuscarFaturaPorId/{idFatura}")]
        public async Task<IActionResult> BuscarFaturaPorId(int idFatura)
        {
            if (idFatura <= 0) return BadRequest("Código inválido!");

            var retornoFatura = await _faturaServices.GetFaturaById(idFatura);

            if (retornoFatura == null) return BadRequest("Não existem registros na base de dados!");

            return Ok(retornoFatura);
        }

        [HttpGet("BuscarInidcadores")]
        public async Task<IActionResult> BuscarInidcadores()
        {
            var retornoIndicadores = await _faturaServices.GetIndicadoresFaturas();

            if (retornoIndicadores.Count() <= 0) return BadRequest("Não existem registros na base de dados!");

            return Ok(retornoIndicadores);
        }

        [HttpGet("DistribuicoFaturasPorStatus")]
        public async Task<IActionResult> DistribuicoFaturasPorStatus()
        {
            var retornoDistribuicoFaturas = await _faturaServices.GetDistribuicoFaturasPorStatus();

            if (retornoDistribuicoFaturas == null) return BadRequest("Não existem registros na base de dados!");

            return Ok(retornoDistribuicoFaturas);
        }

        [HttpGet("ObterEvolucaoMensal")]
        public async Task<IActionResult> ObterEvolucaoMensal()
        {
            var retornoDistribuicoFaturas = await _faturaServices.GetEvolucaoMensal();

            if (retornoDistribuicoFaturas == null) return BadRequest("Não existem registros na base de dados!");

            return Ok(retornoDistribuicoFaturas);
        }



        [HttpPost("FaturaAdicionar")]
        public async Task<IActionResult> FaturaAdicionar(FaturaAdicionarAtualizarDto fatura)
        {
            if (fatura == null) return BadRequest("Dados inválidos!");

            var retornoFaturaAdicionar = await _faturaServices.PostFatura(fatura);

            return Ok(retornoFaturaAdicionar);
        }


        [HttpPut("FaturaAtualizar/{idFatura}")]
        public async Task<IActionResult> FaturaAtualizar(int idFatura, FaturaAdicionarAtualizarDto fatura)
        {
            if (idFatura <= 0 || fatura == null) return BadRequest("Objeto inválido!");

            var retornoFaturaAtualizar = await _faturaServices.PutFatura(idFatura, fatura);

            return Ok(retornoFaturaAtualizar);
        }


        [HttpDelete("FaturaEliminar/{idFatura}")]
        public async Task<IActionResult> FaturaEliminar(int idFatura)
        {
            if (idFatura <= 0) return BadRequest("Código inválido!");

            var retornoFaturaEliminar = await _faturaServices.DeleteFatura(idFatura);

            return Ok(retornoFaturaEliminar);
        }

    }
}
