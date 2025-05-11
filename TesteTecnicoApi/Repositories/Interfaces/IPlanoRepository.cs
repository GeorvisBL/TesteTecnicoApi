using TesteTecnicoApi.Dto.Plano;
using TesteTecnicoApi.Models;

namespace TesteTecnicoApi.Repositories.Interfaces
{
    public interface IPlanoRepository
    {
        public Task<IEnumerable<PlanoDto>> GetListaPlanosAsync();
    }
}
