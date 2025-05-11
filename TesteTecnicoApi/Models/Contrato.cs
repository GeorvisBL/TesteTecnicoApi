namespace TesteTecnicoApi.Models
{
    public class Contrato
    {
        public int Id { get; set; }
        public int IdOperadora { get; set; }
        public int IdPlano { get; set; }
        public string NomeFilial { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal ValorMensal { get; set; }
        public bool Status { get; set; }


        public virtual Plano Plano { get; set; }
        public virtual Operadora Operadora { get; set; }
        public virtual ICollection<Fatura> Faturas { get; set; }
    }
}
