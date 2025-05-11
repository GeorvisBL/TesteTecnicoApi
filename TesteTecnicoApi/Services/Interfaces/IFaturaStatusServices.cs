using TesteTecnicoApi.Dto.FaturaStatus;

namespace TesteTecnicoApi.Services.Interfaces
{
    public interface IFaturaStatusServices
    {
        public Task<IEnumerable<FaturaStatusDto>> GetListaFaturaStatus();
    }
}
