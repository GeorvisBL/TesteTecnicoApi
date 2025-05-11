using TesteTecnicoApi.Dto.Operadora;
using TesteTecnicoApi.Models;

namespace TesteTecnicoApi.Repositories.Interfaces
{
    public interface IOperadoraRepository
    {
        public Task<IEnumerable<OperadoraDto>> GetListaOperadorasAsync();
        public Task<OperadoraDto> GetOperadoraByIdAsync(int idOperadora);
        public Task<Operadora> BuscarOperadoraPorIdAsync(int idOperadora);

        void PostOperadora(Operadora operadora);
        void PutOperadora(Operadora operadora);
        void DeleteOperadora(Operadora operadora);
        Task<bool> SaveChangesAsync();
    }
}
