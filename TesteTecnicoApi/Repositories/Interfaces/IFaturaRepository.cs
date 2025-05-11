using TesteTecnicoApi.Dto.Fatura;
using TesteTecnicoApi.Models;

namespace TesteTecnicoApi.Repositories.Interfaces
{
    public interface IFaturaRepository
    {
        public Task<IEnumerable<FaturaDto>> GetListaFaturasAsync();
        public Task<FaturaDto> GetFaturaByIdAsync(int idFatura);
        public Task<Fatura> BuscarFaturaPorIdAsync(int idFatura);
        public Task<IEnumerable<Fatura>> BuscarListaFaturasAsync();

        void PostFatura(Fatura fatura);
        void PutFatura(Fatura fatura);
        void DeleteFatura(Fatura fatura);
        Task<bool> SaveChangesAsync();
    }
}
