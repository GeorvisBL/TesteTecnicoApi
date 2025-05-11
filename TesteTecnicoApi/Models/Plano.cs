namespace TesteTecnicoApi.Models
{
    public class Plano
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<Contrato> Contratos { get; set; }
    }
}
