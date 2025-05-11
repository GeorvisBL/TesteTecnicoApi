using TesteTecnicoApi.Dto.Contrato;
using TesteTecnicoApi.Models;

namespace TesteTecnicoApi.Repositories.Interfaces
{
    public interface IContratoRepository
    {
        public Task<IEnumerable<ContratoDto>> GetListaContratosAsync();
        public Task<ContratoDto> GetContratoByIdAsync(int id);
        public Task<Contrato> BuscarContratoPorIdAsync(int id);

        void PostContrato(Contrato contrato);
        void PutContrato(Contrato contrato);
        void DeleteContrato(Contrato contrato);
        Task<bool> SaveChangesAsync();
    }
}
