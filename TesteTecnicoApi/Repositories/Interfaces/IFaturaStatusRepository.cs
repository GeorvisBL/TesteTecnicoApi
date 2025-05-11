using TesteTecnicoApi.Dto.FaturaStatus;

namespace TesteTecnicoApi.Repositories.Interfaces
{
    public interface IFaturaStatusRepository
    {
        public Task<IEnumerable<FaturaStatusDto>> GetListaFaturaStatusAsync();
    }
}
