using Microsoft.EntityFrameworkCore;
using Audit.EntityFramework;
using GCAC.Core.Entidades.Localidade;
using GCAC.Core.Entidades.Log;
using GCAC.Core.Entidades.InstrumentoColetivo;

namespace GCAC.Infrastructure.Contextos
{
    /// <summary>
    /// Contexto da aplicação
    /// </summary>
    public partial class Context : AuditDbContext
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public Context()
        {
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="options">Opções de inicialização do contexto</param>
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        /// <summary>
        /// Método de configuração
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        /// <summary>
        /// Definição e mapeamento das entidades
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region InstrumentoColetivo

            modelBuilder.Entity<Abrangencia>(entity =>
            {
                entity.ToTable("Abrangencia", schema: "InstrumentoColetivo");
                entity.HasKey(e => e.Id).HasName("PK_Abrangencia_Id");
                entity.HasIndex(e => e.Descricao).IsUnique().HasDatabaseName("IX_Abrangencia_Nome");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.ToTable("Categoria", schema: "InstrumentoColetivo");
                entity.HasKey(e => e.Id).HasName("PK_Categoria_Id");
                entity.HasIndex(e => e.Descricao).IsUnique().HasDatabaseName("IX_Categoria_Nome");
            });

            modelBuilder.Entity<Classificacao>(entity =>
            {
                entity.ToTable("Classificacao", schema: "InstrumentoColetivo");
                entity.HasKey(e => e.Id).HasName("PK_Classificacao_Id");
                entity.HasIndex(e => e.Descricao).IsUnique().HasDatabaseName("IX_Classificacao_Nome");
            });

            modelBuilder.Entity<Clausula>(entity =>
            {
                entity.ToTable("Clausula", schema: "InstrumentoColetivo");
                entity.HasKey(e => e.Id).HasName("PK_Clausula_Id");
                entity.HasOne<ClausulaSubGrupo>().WithMany().HasForeignKey(e => e.ClausulaSubGrupoId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Clausula_ClausulaSubGrupo");
                entity.HasIndex(e => new { e.Titulo, e.ClausulaSubGrupoId }).IsUnique().HasDatabaseName("IX_Clausula_Titulo_ClausulaSubGrupoId");
            });

            modelBuilder.Entity<ClausulaGrupo>(entity =>
            {
                entity.ToTable("ClausulaGrupo", schema: "InstrumentoColetivo");
                entity.HasKey(e => e.Id).HasName("PK_ClausulaGrupo_Id");
                entity.HasIndex(e => e.Descricao).IsUnique().HasDatabaseName("IX_ClausulaGrupo_Descricao");
            });

            modelBuilder.Entity<ClausulaSubGrupo>(entity =>
            {
                entity.ToTable("ClausulaSubGrupo", schema: "InstrumentoColetivo");
                entity.HasKey(e => e.Id).HasName("PK_ClausulaSubGrupo_Id");
                entity.HasOne<ClausulaSubGrupo>().WithMany().HasForeignKey(e => e.ClausulaGrupoId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Clausula_ClausulaGrupo");
                entity.HasIndex(e => new { e.Descricao, e.ClausulaGrupoId }).IsUnique().HasDatabaseName("IX_ClausulaSubGrupo_Descricao_ClausulaGrupoId");
            });

            modelBuilder.Entity<EntidadeSindical>(entity =>
            {
                entity.ToTable("EntidadeSindical", schema: "InstrumentoColetivo");
                entity.HasKey(e => e.Id).HasName("PK_EntidadeSindical_Id");
                entity.HasOne<Estado>().WithMany().HasForeignKey(e => e.EstadoId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_EntidadeSindical_Estado");
                entity.HasOne<Municipio>().WithMany().HasForeignKey(e => e.MunicipioId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_EntidadeSindical_Municipio");
                entity.HasIndex(e => e.CNPJ).IsUnique().HasDatabaseName("IX_EntidadeSindical_CNPJ");
            });

            #endregion

            #region Localidade

            modelBuilder.Entity<Pais>(entity =>
            {
                entity.ToTable("Pais", schema: "Localidade");
                entity.HasKey(e => e.Id).HasName("PK_Pais_Id");
                entity.HasIndex(e => e.Nome).IsUnique().HasDatabaseName("IX_Pais_Nome");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.ToTable("Estado", schema: "Localidade");
                entity.HasKey(e => e.Id).HasName("PK_Estado_Id");
                entity.HasOne<Pais>().WithMany().HasForeignKey(e => e.PaisId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Estado_Pais");
                entity.HasIndex(e => new { e.Nome, e.PaisId }).IsUnique().HasDatabaseName("IX_Estado_Nome_PaisId");
            });

            modelBuilder.Entity<Municipio>(entity =>
            {
                entity.ToTable("Municipio", schema: "Localidade");
                entity.HasKey(e => e.Id).HasName("PK_Municipio_Id");
                entity.HasOne<Estado>().WithMany().HasForeignKey(e => e.EstadoId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Municipio_Estado");
                entity.HasIndex(e => new { e.Nome, e.EstadoId }).IsUnique().HasDatabaseName("IX_Municipio_Nome_EstadoId");
            });

            modelBuilder.Entity<Regiao>(entity =>
            {
                entity.ToTable("Regiao", schema: "Localidade");
                entity.HasKey(e => e.Id).HasName("PK_Regiao_Id");
                entity.HasIndex(e => e.Descricao).IsUnique().HasDatabaseName("IX_Regiao_Descricao");
            });

            #endregion

            #region Log

            modelBuilder.Entity<Auditoria>(entity =>
            {
                entity.ToTable("Auditoria", schema: "Log");
                entity.HasKey(e => e.Id).HasName("PK_Log.Auditoria_Id");
            });

            modelBuilder.Entity<Erro>(entity =>
            {
                entity.ToTable("Erro", schema: "Log");
                entity.HasKey(e => e.Id).HasName("PK_Log.Erro_Id");
            });

            #endregion

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        #region InstrumentoColetivo

        /// <summary>
        /// Entidade para persistência de abrangências
        /// </summary>
        public virtual DbSet<Abrangencia> Abrangencia { get; set; }

        /// <summary>
        /// Entidade para persistência de categorias
        /// </summary>
        public virtual DbSet<Categoria> Categoria { get; set; }

        /// <summary>
        /// Entidade para persistência de classificações
        /// </summary>
        public virtual DbSet<Classificacao> Classificacao { get; set; }

        /// <summary>
        /// Entidade para persistência de cláusulas
        /// </summary>
        public virtual DbSet<Clausula> Clausula { get; set; }

        /// <summary>
        /// Entidade para persistência de grupo de cláusulas
        /// </summary>
        public virtual DbSet<ClausulaGrupo> ClausulaGrupo { get; set; }

        /// <summary>
        /// Entidade para persistência de sub-grupo de cláusulas
        /// </summary>
        public virtual DbSet<ClausulaSubGrupo> ClausulaSubGrupo { get; set; }

        /// <summary>
        /// Entidade para persistência de entidades sindicais
        /// </summary>
        public virtual DbSet<EntidadeSindical> EntidadeSindical { get; set; }

        #endregion

        #region Localidade

        /// <summary>
        /// Entidade para persistência de países
        /// </summary>
        public virtual DbSet<Pais> Pais { get; set; }

        /// <summary>
        /// Entidade para persistência de estados
        /// </summary>
        public virtual DbSet<Estado> Estado { get; set; }

        /// <summary>
        /// Entidade para persistência de municípios
        /// </summary>
        public virtual DbSet<Municipio> Municipio { get; set; }

        /// <summary>
        /// Entidade para persistência de regiões
        /// </summary>
        public virtual DbSet<Regiao> Regiao { get; set; }

        #endregion

        #region Log

        /// <summary>
        /// Entidade para log de operações no banco de dados
        /// </summary>
        public virtual DbSet<Auditoria> Auditoria { get; set; }

        /// <summary>
        /// Entidade para log de operações com erros no banco de dados
        /// </summary>
        public virtual DbSet<Erro> Erro { get; set; }

        #endregion
    }
}