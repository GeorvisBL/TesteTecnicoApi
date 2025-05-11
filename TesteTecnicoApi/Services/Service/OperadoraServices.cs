using TesteTecnicoApi.Dto;
using TesteTecnicoApi.Dto.Operadora;
using TesteTecnicoApi.Models;
using TesteTecnicoApi.Repositories.Interfaces;
using TesteTecnicoApi.Services.Interfaces;

namespace TesteTecnicoApi.Services.Service
{
    public class OperadoraServices : IOperadoraServices
    {

        private readonly IOperadoraRepository _operadoraRepository;
        public OperadoraServices(IOperadoraRepository operadoraRepository)
        {
            _operadoraRepository = operadoraRepository;
        }



        public async Task<IEnumerable<OperadoraDto>> GetListaOperadoras()
        {
            var operadoras = await _operadoraRepository.GetListaOperadorasAsync();

            return operadoras;
        }

        public async Task<OperadoraDto> GetOperadoraById(int idOperadora)
        {
            var operadora = await _operadoraRepository.GetOperadoraByIdAsync(idOperadora);

            return operadora;
        }



        public async Task<RetornoDto> PostOperadora(OperadoraAdicionarAtualizarDto operadora)
        {
            var retorno = new RetornoDto()
            {
                Status = false,
                Msg = "Erro ao cadastrar a Operadora!"
            };

            var newOperadora = new Operadora
            {
                IdTipoServico = operadora.IdTipoServico,
                NomeOperadora = operadora.NomeOperadora,
                ContatoSuporte = operadora.ContatoSuporte
            };

            _operadoraRepository.PostOperadora(newOperadora);

            if (await _operadoraRepository.SaveChangesAsync())
            {
                retorno.Status = true;
                retorno.Msg = "Operadora cadastrada com sucesso!";
            }

            return retorno;
        }

        public async Task<RetornoDto> PutOperadora(int idOperadora, OperadoraAdicionarAtualizarDto operadora)
        {
            var retorno = new RetornoDto()
            {
                Status = false,
                Msg = "Erro ao atualizar a Operadora!"
            };

            var retornoOperadoraBanco = await _operadoraRepository.BuscarOperadoraPorIdAsync(idOperadora);
            if (retornoOperadoraBanco == null) return retorno;

            retornoOperadoraBanco.IdTipoServico = operadora.IdTipoServico;
            retornoOperadoraBanco.NomeOperadora = operadora.NomeOperadora;
            retornoOperadoraBanco.ContatoSuporte = operadora.ContatoSuporte;

            _operadoraRepository.PutOperadora(retornoOperadoraBanco);

            if (await _operadoraRepository.SaveChangesAsync())
            {
                retorno.Status = true;
                retorno.Msg = "Operadora atualizada com sucesso!";
            }

            return retorno;
        }

        public async Task<RetornoDto> DeleteOperadora(int idOperadora)
        {
            var retorno = new RetornoDto()
            {
                Status = false,
                Msg = "Erro ao excluir os dados da Operadora!"
            };

            var retornoOperadoraBanco = await _operadoraRepository.BuscarOperadoraPorIdAsync(idOperadora);
            if (retornoOperadoraBanco == null) return retorno;

            _operadoraRepository.DeleteOperadora(retornoOperadoraBanco);

            if (await _operadoraRepository.SaveChangesAsync())
            {
                retorno.Status = true;
                retorno.Msg = "Operadora excluida com sucesso!";
            }

            return retorno;
        }

    }
}
