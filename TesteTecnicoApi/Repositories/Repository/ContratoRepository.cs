using Microsoft.EntityFrameworkCore;
using TesteTecnicoApi.Context;
using TesteTecnicoApi.Dto.Contrato;
using TesteTecnicoApi.Models;
using TesteTecnicoApi.Repositories.Interfaces;

namespace TesteTecnicoApi.Repositories.Repository
{
    public class ContratoRepository : IContratoRepository
    {

        private readonly DBContext _context;
        public ContratoRepository(DBContext context)
        {
            _context = context;
        }

        
        public async Task<IEnumerable<ContratoDto>> GetListaContratosAsync()
        {
            var retorno = await _context.Contrato
                .Select(x => new ContratoDto
                {
                    Id = x.Id,
                    Operadora = x.Operadora.NomeOperadora,
                    Plano = x.Plano.Descricao,
                    NomeFilial = x.NomeFilial,
                    DataInicio = x.DataInicio.ToString("dd/MM/yyyy"),
                    DataVencimento = x.DataVencimento.ToString("dd/MM/yyyy"),
                    ValorMensal = x.ValorMensal,
                    Status = x.Status,
                })
                .ToListAsync();

            return retorno;
        }

        public async Task<ContratoDto> GetContratoByIdAsync(int id)
        {
            var retorno = await _context.Contrato
                .Where(x => x.Id == id)
                .Select(x => new ContratoDto
                {
                    Id = x.Id,
                    Operadora = x.Operadora.NomeOperadora,
                    Plano = x.Plano.Descricao,
                    NomeFilial = x.NomeFilial,
                    DataInicio = x.DataInicio.ToString("dd/MM/yyyy"),
                    DataVencimento = x.DataVencimento.ToString("dd/MM/yyyy"),
                    ValorMensal = x.ValorMensal,
                    Status = x.Status,
                })
                .FirstOrDefaultAsync();

            return retorno;
        }


        public async Task<Contrato> BuscarContratoPorIdAsync(int id)
        {
            var retorno = await _context.Contrato
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return retorno;
        }

        public void PostContrato(Contrato contrato)
        {
            _context.Contrato.Add(contrato);
        }

        public void PutContrato(Contrato contrato)
        {
            _context.Contrato.Update(contrato);
        }

        public void DeleteContrato(Contrato contrato)
        {
            _context.Contrato.Remove(contrato);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
