using TesteTecnicoApi.Dto;
using TesteTecnicoApi.Dto.Contrato;

namespace TesteTecnicoApi.Services.Interfaces
{
    public interface IContratoServices
    {
        Task<IEnumerable<ContratoDto>> GetListaContratos();
        Task<ContratoDto> GetContratoById(int id);

        Task<RetornoDto> PostContrato(ContratoAdicionarAtualizarDto contrato);
        Task<RetornoDto> PutContrato(int idContrato, ContratoAdicionarAtualizarDto contrato);
        Task<RetornoDto> DeleteContrato(int idContrato);
    }
}
