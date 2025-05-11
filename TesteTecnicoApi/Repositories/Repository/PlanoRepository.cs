using Microsoft.EntityFrameworkCore;
using TesteTecnicoApi.Context;
using TesteTecnicoApi.Dto.Plano;
using TesteTecnicoApi.Models;
using TesteTecnicoApi.Repositories.Interfaces;

namespace TesteTecnicoApi.Repositories.Repository
{
    public class PlanoRepository : IPlanoRepository
    {


        private readonly DBContext _context;
        public PlanoRepository(DBContext context)
        {
            _context = context;
        }



        public async Task<IEnumerable<PlanoDto>> GetListaPlanosAsync()
        {
            var retorno = await _context.Plano
                .Select(x => new PlanoDto
                {
                    Id = x.Id,
                    Descricao = x.Descricao,
                    Ativo = x.Ativo
                })
                .ToListAsync();

            return retorno;
        }

    }
}
