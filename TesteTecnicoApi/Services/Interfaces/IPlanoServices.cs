using TesteTecnicoApi.Dto.Plano;

namespace TesteTecnicoApi.Services.Interfaces
{
    public interface IPlanoServices
    {
        public Task<IEnumerable<PlanoDto>> GetListaPlanos();
    }
}
