using TesteTecnicoApi.Dto.FaturaStatus;
using TesteTecnicoApi.Repositories.Interfaces;
using TesteTecnicoApi.Services.Interfaces;

namespace TesteTecnicoApi.Services.Service
{
    public class FaturaStatusServices : IFaturaStatusServices
    {

        private readonly IFaturaStatusRepository _faturaStatusRepository;
        public FaturaStatusServices(IFaturaStatusRepository faturaStatusRepository)
        {
            _faturaStatusRepository = faturaStatusRepository;
        }


        public async Task<IEnumerable<FaturaStatusDto>> GetListaFaturaStatus()
        {
            var faturaStatus = await _faturaStatusRepository.GetListaFaturaStatusAsync();

            return faturaStatus;
        }

    }
}
