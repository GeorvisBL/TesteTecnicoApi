using TesteTecnicoApi.Dto;
using TesteTecnicoApi.Dto.Plano;
using TesteTecnicoApi.Models;
using TesteTecnicoApi.Repositories.Interfaces;
using TesteTecnicoApi.Services.Interfaces;

namespace TesteTecnicoApi.Services.Service
{
    public class PlanoServices : IPlanoServices
    {

        private readonly IPlanoRepository _planoRepository;
        public PlanoServices(IPlanoRepository planoRepository)
        {
            _planoRepository = planoRepository;
        }



        public async Task<IEnumerable<PlanoDto>> GetListaPlanos()
        {
            var planos = await _planoRepository.GetListaPlanosAsync();

            return planos;
        }

    }
}
