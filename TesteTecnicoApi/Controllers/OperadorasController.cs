using Microsoft.AspNetCore.Mvc;
using TesteTecnicoApi.Dto.Operadora;
using TesteTecnicoApi.Services.Interfaces;

namespace TesteTecnicoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperadorasController : ControllerBase
    {

        private readonly IOperadoraServices _operadoraServices;
        public OperadorasController(IOperadoraServices operadoraServices)
        {
            _operadoraServices = operadoraServices;
        }



        [HttpGet("BuscarOperadoras")]
        public async Task<IActionResult> BuscarOperadoras()
        {
            var retornoOperadoras = await _operadoraServices.GetListaOperadoras();

            if (retornoOperadoras.Count() <= 0) return BadRequest("Não existem registros na base de dados!");

            return Ok(retornoOperadoras);
        }


        [HttpGet("BuscarOperadoraPorId/{idOperadora}")]
        public async Task<IActionResult> BuscarOperadoraPorId(int idOperadora)
        {
            if (idOperadora <= 0) return BadRequest("Código inválido!");

            var retornoOperadora = await _operadoraServices.GetOperadoraById(idOperadora);

            if (retornoOperadora == null) return BadRequest("Não existem registros na base de dados!");

            return Ok(retornoOperadora);
        }



        [HttpPost("OperadoraAdicionar")]
        public async Task<IActionResult> OperadoraAdicionar(OperadoraAdicionarAtualizarDto operadora)
        {
            if (operadora == null) return BadRequest("Dados inválidos!");

            var retornoOperadoraAdicionar = await _operadoraServices.PostOperadora(operadora);

            return Ok(retornoOperadoraAdicionar);
        }


        [HttpPut("OperadoraAtualizar/{idOperadora}")]
        public async Task<IActionResult> OperadoraAtualizar(int idOperadora, OperadoraAdicionarAtualizarDto operadora)
        {
            if (idOperadora <= 0 || operadora == null) return BadRequest("Objeto inválido!");

            var retornoOperadoraAtualizar = await _operadoraServices.PutOperadora(idOperadora, operadora);

            return Ok(retornoOperadoraAtualizar);
        }


        [HttpDelete("OperadoraEliminar/{idOperadora}")]
        public async Task<IActionResult> OperadoraEliminar(int idOperadora)
        {
            if (idOperadora <= 0) return BadRequest("Código inválido!");

            var retornoOperadoraEliminar = await _operadoraServices.DeleteOperadora(idOperadora);

            return Ok(retornoOperadoraEliminar);
        }

    }
}
