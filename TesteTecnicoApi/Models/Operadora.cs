namespace TesteTecnicoApi.Models
{
    public class Operadora
    {
        public int Id { get; set; }
        public int IdTipoServico { get; set; }
        public string NomeOperadora { get; set; }
        public string ContatoSuporte { get; set; }


        public virtual TipoServico TipoServico { get; set; }
        public virtual ICollection<Contrato> Contratos { get; set; }
    }
}
