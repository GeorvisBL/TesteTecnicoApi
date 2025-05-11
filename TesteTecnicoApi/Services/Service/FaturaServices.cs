using System.Data;
using System.Globalization;
using TesteTecnicoApi.Dto;
using TesteTecnicoApi.Dto.Fatura;
using TesteTecnicoApi.Models;
using TesteTecnicoApi.Repositories.Interfaces;
using TesteTecnicoApi.Services.Interfaces;

namespace TesteTecnicoApi.Services.Service
{
    public class FaturaServices : IFaturaServices
    {

        private readonly IFaturaRepository _faturaRepository;
        public FaturaServices(IFaturaRepository faturaRepository)
        {
            _faturaRepository = faturaRepository;
        }


        public async Task<IEnumerable<FaturaDto>> GetListaFaturas()
        {
            var faturas = await _faturaRepository.GetListaFaturasAsync();

            return faturas;
        }

        public async Task<FaturaDto> GetFaturaById(int idFatura)
        {
            var fatura = await _faturaRepository.GetFaturaByIdAsync(idFatura);

            return fatura;
        }

        public async Task<IEnumerable<IndicadoresDto>> GetIndicadoresFaturas()
        {
            List<IndicadoresDto> indicadores = new List<IndicadoresDto>();
            var faturas = await _faturaRepository.GetListaFaturasAsync();

            if (faturas.Count() <= 0) return indicadores;

            ObterTotalFaturasEmitidas(faturas, indicadores);

            ObterValorFaturado(faturas, indicadores);


            return indicadores;
        }

        public async Task<DistribuicaoFaturasPorStatusDto> GetDistribuicoFaturasPorStatus()
        {
            DistribuicaoFaturasPorStatusDto distribuicaoFaturas = new DistribuicaoFaturasPorStatusDto();

            var faturas = await _faturaRepository.GetListaFaturasAsync();
            if (faturas.Count() <= 0) return distribuicaoFaturas;

            var statusList = new[] { "Paga", "Pendente", "Atrasada" };

            foreach (var status in statusList)
            {
                var count = faturas.Count(x => x.FaturaStatus == status).ToString();
                distribuicaoFaturas.ListaTipoFatura.Add(status);
                distribuicaoFaturas.ListaValor.Add(count);
            }
            return distribuicaoFaturas;
        }

        public async Task<EvolucaoMensalDto> GetEvolucaoMensal()
        {
            EvolucaoMensalDto evolucaoMensalDto = new EvolucaoMensalDto();

            var faturas = await _faturaRepository.BuscarListaFaturasAsync();
            if (faturas.Count() <= 0) return evolucaoMensalDto;

            for (int i = 1; i < 13; i++)
            {
                var count = faturas.Count(x => x.DataEmissao.Month == i && x.DataEmissao.Year == 2025 && x.IdFaturaStatus == 1).ToString();
                string nomeMes = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i);

                evolucaoMensalDto.ListaMeses.Add(nomeMes);
                evolucaoMensalDto.ListaValor.Add(count);
            }

            return evolucaoMensalDto;
        }


        public async Task<RetornoDto> PostFatura(FaturaAdicionarAtualizarDto fatura)
        {
            var retorno = new RetornoDto()
            {
                Status = false,
                Msg = "Erro ao cadastrar a Fatura!"
            };

            var newFatura = new Fatura
            {
                IdContrato = fatura.IdContrato,
                IdFaturaStatus = fatura.IdFaturaStatus,
                DataEmissao = fatura.DataEmissao,
                DataVencimento = fatura.DataVencimento,
                ValorCobrado = fatura.ValorCobrado,
            };

            _faturaRepository.PostFatura(newFatura);

            if (await _faturaRepository.SaveChangesAsync())
            {
                retorno.Status = true;
                retorno.Msg = "fatura cadastrada com sucesso!";
            }

            return retorno;
        }

        public async Task<RetornoDto> PutFatura(int idFatura, FaturaAdicionarAtualizarDto fatura)
        {
            var retorno = new RetornoDto()
            {
                Status = false,
                Msg = "Erro ao atualizar a Fatura!"
            };

            var retornoFaturaBanco = await _faturaRepository.BuscarFaturaPorIdAsync(idFatura);
            if (retornoFaturaBanco == null) return retorno;

            retornoFaturaBanco.IdContrato = fatura.IdContrato;
            retornoFaturaBanco.IdFaturaStatus = fatura.IdFaturaStatus;
            retornoFaturaBanco.DataEmissao = fatura.DataEmissao;
            retornoFaturaBanco.DataVencimento = fatura.DataVencimento;
            retornoFaturaBanco.ValorCobrado = fatura.ValorCobrado;

            _faturaRepository.PutFatura(retornoFaturaBanco);

            if (await _faturaRepository.SaveChangesAsync())
            {
                retorno.Status = true;
                retorno.Msg = "Fatura atualizada com sucesso!";
            }

            return retorno;
        }

        public async Task<RetornoDto> DeleteFatura(int idFatura)
        {
            var retorno = new RetornoDto()
            {
                Status = false,
                Msg = "Erro ao excluir os dados da Fatura!"
            };

            var retornoFaturaBanco = await _faturaRepository.BuscarFaturaPorIdAsync(idFatura);
            if (retornoFaturaBanco == null) return retorno;

            _faturaRepository.DeleteFatura(retornoFaturaBanco);

            if (await _faturaRepository.SaveChangesAsync())
            {
                retorno.Status = true;
                retorno.Msg = "Fatura excluida com sucesso!";
            }

            return retorno;
        }



        #region /// Metodos Privados


        private void ObterTotalFaturasEmitidas(IEnumerable<FaturaDto> faturas, List<IndicadoresDto> indicadores)
        {
            var indicador = new IndicadoresDto()
            {
                Titulo = "Total de faturas emitidas",
                Valor = faturas.Count().ToString()
            };

            indicadores.Add(indicador);
        }

        private void ObterValorFaturado(IEnumerable<FaturaDto> faturas, List<IndicadoresDto> indicadores)
        {
            var valorCobrado = faturas.Where(x => x.FaturaStatus == "Paga").Sum(x => x.ValorCobrado);


            var indicador = new IndicadoresDto()
            {
                Titulo = "Valor total faturado",
                Valor = "R$" + valorCobrado.ToString()
            };

            indicadores.Add(indicador);
        }


        #endregion

    }
}
