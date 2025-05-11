using TesteTecnicoApi.Dto.TipoServico;
using TesteTecnicoApi.Repositories.Interfaces;
using TesteTecnicoApi.Services.Interfaces;

namespace TesteTecnicoApi.Services.Service
{
    public class TipoServicoServices : ITipoServicoServices
    {

        private readonly ITipoServicoRepository _tipoServicoRepository;
        public TipoServicoServices(ITipoServicoRepository tipoServicoRepository)
        {
            _tipoServicoRepository = tipoServicoRepository;
        }


        public async Task<IEnumerable<TipoServicoDto>> GetListaTipoServicos()
        {
            var tipoServico = await _tipoServicoRepository.GetListaTipoServicoAsync();

            return tipoServico;
        }

    }
}
