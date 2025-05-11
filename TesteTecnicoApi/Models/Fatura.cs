namespace TesteTecnicoApi.Models
{
    public class Fatura
    {
        public int Id { get; set; }
        public int IdContrato { get; set; }
        public int IdFaturaStatus { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal ValorCobrado { get; set; }


        public virtual FaturaStatus FaturaStatus { get; set; }
        public virtual Contrato Contrato { get; set; }

    }
}
