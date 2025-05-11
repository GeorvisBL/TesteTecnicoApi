namespace TesteTecnicoApi.Dto.Fatura
{
    public class FaturaAdicionarAtualizarDto
    {
        public int IdContrato { get; set; }
        public int IdFaturaStatus { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal ValorCobrado { get; set; }
    }
}
