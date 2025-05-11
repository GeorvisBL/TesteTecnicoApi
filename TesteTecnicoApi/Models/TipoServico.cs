namespace TesteTecnicoApi.Models
{
    public class TipoServico
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }


        public virtual ICollection<Operadora> Operadoras { get; set; }       
    }
}
