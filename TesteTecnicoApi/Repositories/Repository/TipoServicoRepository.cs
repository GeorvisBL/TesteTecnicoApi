using Microsoft.EntityFrameworkCore;
using TesteTecnicoApi.Context;
using TesteTecnicoApi.Dto.TipoServico;
using TesteTecnicoApi.Repositories.Interfaces;

namespace TesteTecnicoApi.Repositories.Repository
{
    public class TipoServicoRepository : ITipoServicoRepository
    {

        private readonly DBContext _context;
        public TipoServicoRepository(DBContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<TipoServicoDto>> GetListaTipoServicoAsync()
        {
            var retorno = await _context.TipoServico
                .Select(x => new TipoServicoDto
                {
                    Id = x.Id,
                    Descricao = x.Descricao
                })
                .ToListAsync();

            return retorno;
        }

    }
}
