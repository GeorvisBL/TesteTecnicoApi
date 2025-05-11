namespace TesteTecnicoApi.Dto.Contrato
{
    public class ContratoDto
    {
        public int Id { get; set; }
        public string Operadora { get; set; }
        public string Plano { get; set; }
        public string NomeFilial { get; set; }
        public string DataInicio { get; set; }
        public string DataVencimento { get; set; }
        public decimal ValorMensal { get; set; }
        public bool Status { get; set; }
    }
}
