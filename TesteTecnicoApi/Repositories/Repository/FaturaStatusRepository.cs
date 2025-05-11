using Microsoft.EntityFrameworkCore;
using TesteTecnicoApi.Context;
using TesteTecnicoApi.Dto.FaturaStatus;
using TesteTecnicoApi.Repositories.Interfaces;

namespace TesteTecnicoApi.Repositories.Repository
{
    public class FaturaStatusRepository : IFaturaStatusRepository
    {

        private readonly DBContext _context;
        public FaturaStatusRepository(DBContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<FaturaStatusDto>> GetListaFaturaStatusAsync()
        {
            var retorno = await _context.FaturaStatus
                .Where(x => x.Ativo)
                .Select(x => new FaturaStatusDto
                {
                    Id = x.Id,
                    Descricao = x.Descricao,
                })
                .ToListAsync();

            return retorno;
        }

    }
}
