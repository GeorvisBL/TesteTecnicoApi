using Microsoft.EntityFrameworkCore;
using TesteTecnicoApi.Context;
using TesteTecnicoApi.Dto.Operadora;
using TesteTecnicoApi.Models;
using TesteTecnicoApi.Repositories.Interfaces;

namespace TesteTecnicoApi.Repositories.Repository
{
    public class OperadoraRepository : IOperadoraRepository
    {

        private readonly DBContext _context;
        public OperadoraRepository(DBContext context)
        {
            _context = context;
        }
        


        public async Task<IEnumerable<OperadoraDto>> GetListaOperadorasAsync()
        {
            var retorno = await _context.Operadora
                .Select(x => new OperadoraDto
                {
                    Id = x.Id,
                    IdTipoServico = x.IdTipoServico,
                    TipoServico = x.TipoServico.Descricao,
                    NomeOperadora = x.NomeOperadora,
                    ContatoSuporte = x.ContatoSuporte
                })
                .ToListAsync();

            return retorno;
        }

        public async Task<OperadoraDto> GetOperadoraByIdAsync(int idOperadora)
        {
            var retorno = await _context.Operadora
                .Where(x => x.Id == idOperadora)
                .Select(x => new OperadoraDto
                {
                    Id = x.Id,
                    IdTipoServico = x.IdTipoServico,
                    TipoServico = x.TipoServico.Descricao,
                    NomeOperadora = x.NomeOperadora,
                    ContatoSuporte = x.ContatoSuporte
                })
                .FirstOrDefaultAsync();

            return retorno;
        }

        public async Task<Operadora> BuscarOperadoraPorIdAsync(int idOperadora)
        {
            var retorno = await _context.Operadora
                .Where(x => x.Id == idOperadora)
                .FirstOrDefaultAsync();

            return retorno;
        }
               



        public void PostOperadora(Operadora operadora)
        {
            _context.Operadora.Add(operadora);
        }

        public void PutOperadora(Operadora operadora)
        {
            _context.Operadora.Update(operadora);
        }

        public void DeleteOperadora(Operadora operadora)
        {
            _context.Operadora.Remove(operadora);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
