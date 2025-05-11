using Microsoft.EntityFrameworkCore;
using TesteTecnicoApi.Models;

namespace TesteTecnicoApi.Context
{
    public partial class DBContext : DbContext 
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
           : base(options)
        {
        }


        public virtual DbSet<Contrato> Contrato { get; set; }
        public virtual DbSet<Fatura> Fatura { get; set; }
        public virtual DbSet<FaturaSatatus> FaturaSatatus { get; set; }
        public virtual DbSet<Operadora> Operadora { get; set; }
        public virtual DbSet<Plano> Plano { get; set; }
        public virtual DbSet<TipoServico> TipoServico { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contrato>(entity =>
            {
                entity.Property(e => e.NomeFilial).IsRequired().HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.DataInicio).IsRequired().HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.DataVencimento).IsRequired().HasColumnType("datetime");
                entity.Property(e => e.ValorMensal).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Operadora).WithMany(p => p.Contratos).HasForeignKey(d => d.IdOperadora).HasConstraintName("FK_Contrato_OperadoraId");
                entity.HasOne(d => d.Plano).WithMany(p => p.Contratos).HasForeignKey(d => d.IdPlano).HasConstraintName("FK_Contrato_PlanoId");
            });

            modelBuilder.Entity<Fatura>(entity =>
            {
                entity.Property(e => e.DataEmissao).IsRequired().HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.DataVencimento).IsRequired().HasColumnType("datetime");
                entity.Property(e => e.ValorCobrado).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Contrato).WithMany(p => p.Faturas).HasForeignKey(d => d.IdContrato).HasConstraintName("FK_Fatura_ContratoId");
                entity.HasOne(d => d.FaturaSatatus).WithMany(p => p.Faturas).HasForeignKey(d => d.IdFaturaStatus).HasConstraintName("FK_Fatura_FaturaStatusId");
            });

            modelBuilder.Entity<FaturaSatatus>(entity =>
            {
                entity.Property(e => e.Descricao).IsRequired().HasMaxLength(25).IsUnicode(false);
                entity.Property(e => e.Ativo).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Operadora>(entity =>
            {
                entity.Property(e => e.NomeOperadora).IsRequired().HasMaxLength(10).IsUnicode(false);
                entity.Property(e => e.ContatoSuporte).IsRequired().HasMaxLength(10).IsUnicode(false);

                entity.HasOne(d => d.TipoServico).WithMany(p => p.Operadoras).HasForeignKey(d => d.IdTipoServico).HasConstraintName("FK_Operadora_TipoServicoId");
            });

            modelBuilder.Entity<Plano>(entity =>
            {
                entity.Property(e => e.Descricao).IsRequired().HasMaxLength(25).IsUnicode(false);
                entity.Property(e => e.Ativo).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<TipoServico>(entity =>
            {
                entity.Property(e => e.Descricao).IsRequired().HasMaxLength(25).IsUnicode(false);
                entity.Property(e => e.Ativo).HasDefaultValueSql("((1))");
            });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
