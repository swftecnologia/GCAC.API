using Microsoft.EntityFrameworkCore;
using Audit.EntityFramework;
using GCAC.Core.Entidades.Localidade;
using GCAC.Core.Entidades.Log;
using GCAC.Core.Entidades.InstrumentoColetivo;
using GCAC.Core.Entidades.Participante;

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

            modelBuilder.Entity<Documento>(entity =>
            {
                entity.ToTable("Documento", schema: "InstrumentoColetivo");
                entity.HasKey(e => e.Id).HasName("PK_Documento_Id");
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
                //entity.HasOne<Pais>().WithMany().HasForeignKey(e => e.PaisId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Estado_Pais");
                entity.HasOne(e => e.Pais).WithMany(e => e.Estados).HasForeignKey(e => e.PaisId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Estado_Pais");
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

            #region Participante

            modelBuilder.Entity<Abrangencia>(entity =>
            {
                entity.ToTable("Abrangencia", schema: "Participante");
                entity.HasKey(e => e.Id).HasName("PK_Abrangencia_Id");
                entity.HasIndex(e => e.Descricao).IsUnique().HasDatabaseName("IX_Abrangencia_Descricao");
            });

            modelBuilder.Entity<AbrangenciaTerritorial>(entity =>
            {
                entity.ToTable("AbrangenciaTerritorial", schema: "Participante");
                entity.HasKey(e => new { e.ParticipanteId, e.MunicipioId }).HasName("PK_AbrangenciaTerritorial_ParticipanteId_MunicipioId");

            });

            modelBuilder.Entity<AreaGeoeconomica>(entity =>
            {
                entity.ToTable("AreaGeoeconomica", schema: "Participante");
                entity.HasKey(e => e.Id).HasName("PK_AreaGeoeconomica_Id");
                entity.HasIndex(e => e.Descricao).IsUnique().HasDatabaseName("IX_AreaGeoeconomica_Descricao");
            });

            modelBuilder.Entity<Contato>(entity =>
            {
                entity.ToTable("Contato", schema: "Participante");
                entity.HasKey(e => new { e.Id }).HasName("PK_Contato_Id");
                entity.HasOne(e => e.Participante).WithMany(e => e.Contatos).HasForeignKey(e => e.ParticipanteId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Contato_Participante");
                entity.HasOne(e => e.TipoContato).WithMany(e => e.Contatos).HasForeignKey(e => e.TipoContatoId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Contato_TipoContato");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.ToTable("Endereco", schema: "Participante");
                entity.HasKey(e => new { e.Id }).HasName("PK_Endereco_Id");
                entity.HasOne(e => e.Participante).WithMany(e => e.Endererecos).HasForeignKey(e => e.ParticipanteId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Endereco_Participante");
                entity.HasOne(e => e.Municipio).WithMany(e => e.Endererecos).HasForeignKey(e => e.MunicipioId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Endereco_Municipio");
            });

            modelBuilder.Entity<Funcao>(entity =>
            {
                entity.ToTable("Funcao", schema: "Participante");
                entity.HasKey(e => e.Id).HasName("PK_Funcao_Id");
                entity.HasIndex(e => e.Descricao).IsUnique().HasDatabaseName("IX_Funcao_Descricao");
            });

            modelBuilder.Entity<GrauEntidade>(entity =>
            {
                entity.ToTable("GrauEntidade", schema: "Participante");
                entity.HasKey(e => e.Id).HasName("PK_GrauEntidade_Id");
                entity.HasIndex(e => e.Descricao).IsUnique().HasDatabaseName("IX_GrauEntidade_Descricao");
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.ToTable("Grupo", schema: "Participante");
                entity.HasKey(e => e.Id).HasName("PK_Grupo_Id");
                entity.HasIndex(e => e.Descricao).IsUnique().HasDatabaseName("IX_Grupo_Descricao");
            });

            modelBuilder.Entity<Participante>(entity =>
            {
                entity.ToTable("Participante", schema: "Participante");
                entity.HasKey(e => e.Id).HasName("PK_Participante_Id");
                entity.HasOne(e => e.Abrangencia).WithMany(e => e.Participantes).HasForeignKey(e => e.AbrangenciaId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Participante_Abrangencia");
                entity.HasOne(e => e.AreaGeoeconomica).WithMany(e => e.Participantes).HasForeignKey(e => e.AreaGeoeconomicaId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Participante_AreaGeoeconomica");
                entity.HasOne(e => e.ParticipanteMatriz).WithMany(e => e.Participantes).HasForeignKey(e => e.ParticipanteId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Participante_Participante");
                entity.HasOne(e => e.Funcao).WithMany(e => e.Participantes).HasForeignKey(e => e.FuncaoId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Participante_Funcao");
                entity.HasOne(e => e.GrauEntidade).WithMany(e => e.Participantes).HasForeignKey(e => e.GrauEntidadeId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Participante_GrauEntidade");
                entity.HasOne(e => e.Grupo).WithMany(e => e.Participantes).HasForeignKey(e => e.GrupoId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Participante_Grupo");
                entity.HasOne(e => e.RepresentanteLegal).WithMany(e => e.Participantes).HasForeignKey(e => e.RepresentanteLegalId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Participante_RepresentanteLegal");
                entity.HasOne(e => e.TipoPessoa).WithMany(e => e.Participantes).HasForeignKey(e => e.TipoPessoaId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Participante_TipoPessoa");
            });

            modelBuilder.Entity<RepresentanteLegal>(entity =>
            {
                entity.ToTable("RepresentanteLegal", schema: "Participante");
                entity.HasKey(e => e.Id).HasName("PK_RepresentanteLegal_Id");
                entity.HasIndex(e => e.Descricao).IsUnique().HasDatabaseName("IX_RepresentanteLegal_Descricao");
            });

            modelBuilder.Entity<TipoContato>(entity =>
            {
                entity.ToTable("TipoContato", schema: "Participante");
                entity.HasKey(e => e.Id).HasName("PK_TipoContato_Id");
                entity.HasIndex(e => e.Descricao).IsUnique().HasDatabaseName("IX_TipoContato_Descricao");
            });

            modelBuilder.Entity<TipoPessoa>(entity =>
            {
                entity.ToTable("TipoPessoa", schema: "Participante");
                entity.HasKey(e => e.Id).HasName("PK_TipoPessoa_Id");
                entity.HasIndex(e => e.Descricao).IsUnique().HasDatabaseName("IX_TipoPessoa_Descricao");
            });

            #endregion

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        #region InstrumentoColetivo

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
        /// Entidade para persistência de documentos de instrumentos coletivos
        /// </summary>
        public virtual DbSet<Documento> Documento { get; set; }

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

        #region Participante

        /// <summary>
        /// Entidade para persistência de abrangências do participante
        /// </summary>
        public virtual DbSet<Abrangencia> Abrangencia { get; set; }

        /// <summary>
        /// Entidade para persistência de abrangências territoriais do participante
        /// </summary>
        public virtual DbSet<AbrangenciaTerritorial> AbrangenciaTerritorial { get; set; }

        /// <summary>
        /// Entidade para persistência de áreas geoeconômicas do participante
        /// </summary>
        public virtual DbSet<AreaGeoeconomica> AreaGeoeconomica { get; set; }

        /// <summary>
        /// Entidade para persistência de contatos do participante
        /// </summary>
        public virtual DbSet<Contato> Contato { get; set; }

        /// <summary>
        /// Entidade para persistência de endereços do participante
        /// </summary>
        public virtual DbSet<Endereco> Endereco { get; set; }

        /// <summary>
        /// Entidade para persistência de funções do participante
        /// </summary>
        public virtual DbSet<Funcao> Funcao { get; set; }

        /// <summary>
        /// Entidade para persistência de graus da entidade do participante
        /// </summary>
        public virtual DbSet<GrauEntidade> GrauEntidade { get; set; }

        /// <summary>
        /// Entidade para persistência de grupos do participante
        /// </summary>
        public virtual DbSet<Grupo> Grupo { get; set; }

        //Participante
        /// <summary>
        /// Entidade para persistência de participantes
        /// </summary>
        public virtual DbSet<Participante> Participante { get; set; }

        /// <summary>
        /// Entidade para persistência de representantes legais do participante
        /// </summary>
        public virtual DbSet<RepresentanteLegal> RepresentanteLegal { get; set; }

        /// <summary>
        /// Entidade para persistência de tipos de contato do participante
        /// </summary>
        public virtual DbSet<TipoContato> TipoContato { get; set; }

        /// <summary>
        /// Entidade para persistência de tipos de pessoa do participante
        /// </summary>
        public virtual DbSet<TipoPessoa> TipoPessoa { get; set; }

        #endregion
    }
}