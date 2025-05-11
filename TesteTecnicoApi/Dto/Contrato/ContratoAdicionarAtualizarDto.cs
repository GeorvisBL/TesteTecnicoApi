namespace TesteTecnicoApi.Dto.Contrato
{
    public class ContratoAdicionarAtualizarDto
    {
        public int IdOperadora { get; set; }
        public int IdPlano { get; set; }
        public string NomeFilial { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal ValorMensal { get; set; }
        public bool Status { get; set; }
    }
}
