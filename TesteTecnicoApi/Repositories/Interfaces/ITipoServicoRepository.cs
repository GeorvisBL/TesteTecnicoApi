using TesteTecnicoApi.Dto.TipoServico;

namespace TesteTecnicoApi.Repositories.Interfaces
{
    public interface ITipoServicoRepository
    {
        public Task<IEnumerable<TipoServicoDto>> GetListaTipoServicoAsync();
    }
}
