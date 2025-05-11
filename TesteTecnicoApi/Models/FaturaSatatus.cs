namespace TesteTecnicoApi.Models
{
    public class FaturaSatatus
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }


        public virtual ICollection<Fatura> Faturas { get; set; }
    }
}
