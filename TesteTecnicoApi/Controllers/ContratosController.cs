using Microsoft.AspNetCore.Mvc;
using TesteTecnicoApi.Dto.Contrato;
using TesteTecnicoApi.Services.Interfaces;

namespace TesteTecnicoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratosController : ControllerBase
    {

        private readonly IContratoServices _contratoService;
        public ContratosController(IContratoServices contratoService)
        {
            _contratoService = contratoService;
        }


        [HttpGet("BuscarContratos")]
        public async Task<IActionResult> BuscarContratos()
        {
            var retornoContratos = await _contratoService.GetListaContratos();

            if (retornoContratos.Count() <= 0) return BadRequest("Não existem registros na base de dados!");
            
            return Ok(retornoContratos);
        }


        [HttpGet("BuscarContratosPorId/{idContrato}")]
        public async Task<IActionResult> BuscarContratosPorId(int idContrato)
        {
            if (idContrato <= 0) return BadRequest("Código inválido!");

            var retornoContratos = await _contratoService.GetContratoById(idContrato);

            if (retornoContratos == null) return BadRequest("Não existem registros na base de dados!");

            return Ok(retornoContratos);
        }



        [HttpPost("ContratoAdicionar")]
        public async Task<IActionResult> ContratoAdicionar(ContratoAdicionarAtualizarDto contrato)
        {
            if (contrato == null) return BadRequest("Dados inválidos!");

            var retornoContratoAdicionar = await _contratoService.PostContrato(contrato);

            return Ok(retornoContratoAdicionar);
        }


        [HttpPut("ContratoAtualizar/{idContrato}")]
        public async Task<IActionResult> ContratoAtualizar(int idContrato, ContratoAdicionarAtualizarDto contrato)
        {
            if (idContrato <= 0 || contrato == null) return BadRequest("Objeto inválido!");

            var retornoContratoAtualizar = await _contratoService.PutContrato(idContrato, contrato);

            return Ok(retornoContratoAtualizar);
        }


        [HttpDelete("ContratoEliminar/{idContrato}")]
        public async Task<IActionResult> DeleteEndereco(int idContrato)
        {
            if (idContrato <= 0) return BadRequest("Código inválido!");

            var retornoContratoEliminar = await _contratoService.DeleteContrato(idContrato);

            return Ok(retornoContratoEliminar);
        }

    }
}
