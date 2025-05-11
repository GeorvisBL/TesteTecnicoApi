using Microsoft.EntityFrameworkCore;
using TesteTecnicoApi.Context;
using TesteTecnicoApi.Dto.Contrato;
using TesteTecnicoApi.Dto.Fatura;
using TesteTecnicoApi.Models;
using TesteTecnicoApi.Repositories.Interfaces;

namespace TesteTecnicoApi.Repositories.Repository
{
    public class FaturaRepository : IFaturaRepository
    {

        private readonly DBContext _context;
        public FaturaRepository(DBContext context)
        {
            _context = context;
        }



        public async Task<IEnumerable<FaturaDto>> GetListaFaturasAsync()
        {
            var retorno = await _context.Fatura
                .Select(x => new FaturaDto
                {
                    Id = x.Id,
                    IdContrato = x.IdContrato,
                    Contrato = new ContratoDto
                    {
                        Id = x.Contrato.Id,
                        Operadora = x.Contrato.Operadora.NomeOperadora,
                        Plano = x.Contrato.Plano.Descricao,
                        NomeFilial = x.Contrato.NomeFilial,
                        DataInicio = x.Contrato.DataInicio.ToString("dd/MM/yyyy"),
                        DataVencimento = x.Contrato.DataVencimento.ToString("dd/MM/yyyy"),
                        ValorMensal = x.Contrato.ValorMensal,
                        Status = x.Contrato.Status,
                    },
                    FaturaStatus = x.FaturaSatatus.Descricao,
                    DataEmissao = x.DataEmissao.ToString("dd/MM/yyyy"),
                    DataVencimento = x.DataVencimento.ToString("dd/MM/yyyy"),
                    ValorCobrado = x.ValorCobrado
                })
                .ToListAsync();

            return retorno;
        }

        public async Task<FaturaDto> GetFaturaByIdAsync(int idFatura)
        {
            var retorno = await _context.Fatura
                .Where(x => x.Id == idFatura)
                .Select(x => new FaturaDto
                {
                    Id = x.Id,
                    IdContrato = x.IdContrato,
                    Contrato = new ContratoDto
                    {
                        Id = x.Contrato.Id,
                        Operadora = x.Contrato.Operadora.NomeOperadora,
                        Plano = x.Contrato.Plano.Descricao,
                        NomeFilial = x.Contrato.NomeFilial,
                        DataInicio = x.Contrato.DataInicio.ToString("dd/MM/yyyy"),
                        DataVencimento = x.Contrato.DataVencimento.ToString("dd/MM/yyyy"),
                        ValorMensal = x.Contrato.ValorMensal,
                        Status = x.Contrato.Status,
                    },
                    FaturaStatus = x.FaturaSatatus.Descricao,
                    DataEmissao = x.DataEmissao.ToString("dd/MM/yyyy"),
                    DataVencimento = x.DataVencimento.ToString("dd/MM/yyyy"),
                    ValorCobrado = x.ValorCobrado
                })
                .FirstOrDefaultAsync();

            return retorno;
        }

        public async Task<Fatura> BuscarFaturaPorIdAsync(int idFatura)
        {
            var retorno = await _context.Fatura
                .Where(x => x.Id == idFatura)
                .FirstOrDefaultAsync();

            return retorno;
        }

        public async Task<IEnumerable<Fatura>> BuscarListaFaturasAsync()
        {
            var retorno = await _context.Fatura
                .ToListAsync();

            return retorno;
        }



        public void PostFatura(Fatura fatura)
        {
            _context.Fatura.Add(fatura);
        }

        public void PutFatura(Fatura fatura)
        {
            _context.Fatura.Update(fatura);
        }

        public void DeleteFatura(Fatura fatura)
        {
            _context.Fatura.Remove(fatura);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        
    }
}
