using TesteTecnicoApi.Dto;
using TesteTecnicoApi.Dto.Contrato;
using TesteTecnicoApi.Models;
using TesteTecnicoApi.Repositories.Interfaces;
using TesteTecnicoApi.Services.Interfaces;

namespace TesteTecnicoApi.Services.Service
{
    public class ContratoServices : IContratoServices
    {

        private readonly IContratoRepository _contratoRepository;
        public ContratoServices(IContratoRepository contratoRepository)
        {
            _contratoRepository = contratoRepository;
        }

        
        public async Task<IEnumerable<ContratoDto>> GetListaContratos()
        {
            var contratos = await _contratoRepository.GetListaContratosAsync();

            return contratos;
        }


        public async Task<ContratoDto> GetContratoById(int id)
        {
            var contrato = await _contratoRepository.GetContratoByIdAsync(id);

            return contrato;
        }


        public async Task<RetornoDto> PostContrato(ContratoAdicionarAtualizarDto contrato)
        {
            var retorno = new RetornoDto()
            {
                Status = false,
                Msg = "Erro ao cadastrar o Contrato!"
            };

            var newContrato = new Contrato
            {
                IdOperadora = contrato.IdOperadora,
                IdPlano = contrato.IdPlano,
                NomeFilial = contrato.NomeFilial,
                DataInicio = contrato.DataInicio,
                DataVencimento = contrato.DataVencimento,
                ValorMensal = contrato.ValorMensal,
                Status = contrato.Status,
            };

            _contratoRepository.PostContrato(newContrato);

            if (await _contratoRepository.SaveChangesAsync())
            {
                retorno.Status = true;
                retorno.Msg = "Contrato cadastrado com sucesso!";
            }

            return retorno;
        }

        public async Task<RetornoDto> PutContrato(int idContrato, ContratoAdicionarAtualizarDto contrato)
        {
            var retorno = new RetornoDto()
            {
                Status = false,
                Msg = "Erro ao atualizar o Contrato!"
            };

            var retornoContratoBanco = await _contratoRepository.BuscarContratoPorIdAsync(idContrato);
            if (retornoContratoBanco == null) return retorno;

            retornoContratoBanco.IdOperadora = contrato.IdOperadora;
            retornoContratoBanco.IdPlano = contrato.IdPlano;
            retornoContratoBanco.NomeFilial = contrato.NomeFilial;
            retornoContratoBanco.DataInicio = contrato.DataInicio;
            retornoContratoBanco.DataVencimento = contrato.DataVencimento;
            retornoContratoBanco.ValorMensal = contrato.ValorMensal;
            retornoContratoBanco.Status = contrato.Status;

            _contratoRepository.PutContrato(retornoContratoBanco);

            if (await _contratoRepository.SaveChangesAsync())
            {
                retorno.Status = true;
                retorno.Msg = "Contrato atualizado com sucesso!";
            }

            return retorno;
        }

        public async Task<RetornoDto> DeleteContrato(int idContrato)
        {
            var retorno = new RetornoDto()
            {
                Status = false,
                Msg = "Erro ao excluir os dados do Contrato!"
            };

            var retornoContratoBanco = await _contratoRepository.BuscarContratoPorIdAsync(idContrato);
            if (retornoContratoBanco == null) return retorno;

            _contratoRepository.DeleteContrato(retornoContratoBanco);

            if (await _contratoRepository.SaveChangesAsync())
            {
                retorno.Status = true;
                retorno.Msg = "Contrato excluido com sucesso!";
            }

            return retorno;
        }

    }
}
