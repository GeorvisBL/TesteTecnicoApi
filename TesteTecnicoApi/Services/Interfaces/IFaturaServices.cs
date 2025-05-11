using TesteTecnicoApi.Dto;
using TesteTecnicoApi.Dto.Fatura;

namespace TesteTecnicoApi.Services.Interfaces
{
    public interface IFaturaServices
    {
        public Task<IEnumerable<FaturaDto>> GetListaFaturas();
        public Task<FaturaDto> GetFaturaById(int idFatura);
        public Task<IEnumerable<IndicadoresDto>> GetIndicadoresFaturas();
        public Task<DistribuicaoFaturasPorStatusDto> GetDistribuicoFaturasPorStatus();
        public Task<EvolucaoMensalDto> GetEvolucaoMensal();

        public Task<RetornoDto> PostFatura(FaturaAdicionarAtualizarDto fatura);
        public Task<RetornoDto> PutFatura(int idFatura, FaturaAdicionarAtualizarDto fatura);
        public Task<RetornoDto> DeleteFatura(int idFatura);
    }
}
