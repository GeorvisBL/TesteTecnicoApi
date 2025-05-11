namespace TesteTecnicoApi.Models
{
    public class FaturaStatus
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }


        public virtual ICollection<Fatura> Faturas { get; set; }
    }
}
