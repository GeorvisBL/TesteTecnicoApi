namespace TesteTecnicoApi.Dto.Fatura
{
    public class DistribuicaoFaturasPorStatusDto
    {
        public List<string> ListaTipoFatura { get; set; } = new List<string>();
        public List<string> ListaValor { get; set; } = new List<string>();
    }
}
