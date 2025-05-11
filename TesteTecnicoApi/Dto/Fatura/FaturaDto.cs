using TesteTecnicoApi.Dto.Contrato;

namespace TesteTecnicoApi.Dto.Fatura
{
    public class FaturaDto
    {
        public int Id { get; set; }
        public int IdContrato { get; set; }
        public ContratoDto Contrato { get; set; }
        public string FaturaStatus { get; set; }
        public string DataEmissao { get; set; }
        public string DataVencimento { get; set; }
        public decimal ValorCobrado { get; set; }
    }
}
