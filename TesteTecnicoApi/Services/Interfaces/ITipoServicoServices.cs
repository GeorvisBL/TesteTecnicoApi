using TesteTecnicoApi.Dto.TipoServico;

namespace TesteTecnicoApi.Services.Interfaces
{
    public interface ITipoServicoServices
    {
        public Task<IEnumerable<TipoServicoDto>> GetListaTipoServicos();
    }
}
