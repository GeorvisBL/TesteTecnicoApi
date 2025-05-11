using TesteTecnicoApi.Dto;
using TesteTecnicoApi.Dto.Operadora;

namespace TesteTecnicoApi.Services.Interfaces
{
    public interface IOperadoraServices
    {
        public Task<IEnumerable<OperadoraDto>> GetListaOperadoras();
        public Task<OperadoraDto> GetOperadoraById(int idOperadora);

        public Task<RetornoDto> PostOperadora(OperadoraAdicionarAtualizarDto operadora);
        public Task<RetornoDto> PutOperadora(int idOperadora, OperadoraAdicionarAtualizarDto operadora);
        public Task<RetornoDto> DeleteOperadora(int idOperadora);
    }
}
