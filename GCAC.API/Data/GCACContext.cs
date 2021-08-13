using Microsoft.EntityFrameworkCore;
using GCAC.API.Areas.Usuarios.Contas.Entities;
using GCAC.API.Areas.InstrumentoColetivo.Entities;
using GCAC.API.Areas.Pessoa.Entities;
using Audit.EntityFramework;

namespace GCAC.API.Data
{
    public partial class GCACContext : AuditDbContext
    {
        #region Pessoa

        public virtual DbSet<Cadastro> Cadastro { get; set; }
        public virtual DbSet<CadastroContato> CadastroContato { get; set; }
        public virtual DbSet<CadastroMunicipio> CadastroMunicipio { get; set; }
        public virtual DbSet<Contato> Contato { get; set; }
        public virtual DbSet<Funcao> Funcao { get; set; }
        public virtual DbSet<GrauEntidade> GrauEntidade { get; set; }
        public virtual DbSet<Grupo> Grupo { get; set; }
        public virtual DbSet<RepresentanteLegal> RepresentanteLegal { get; set; }
        public virtual DbSet<Tipo> Tipo { get; set; }

        #endregion

        #region Instrumento Coletivo

        public virtual DbSet<Documento> Documento { get; set; }
        public virtual DbSet<DocumentoMediadorHTML> DocumentoMediadorHTML { get; set; }
        public virtual DbSet<DocumentoEntidadeSindical> DocumentoEntidadeSindical { get; set; }
        public virtual DbSet<DocumentoCategoria> DocumentoCategoria { get; set; }
        public virtual DbSet<DocumentoRepresentante> DocumentoRepresentante { get; set; }
        public virtual DbSet<DocumentoRepresentanteLegal> DocumentoRepresentanteLegal { get; set; }

        #endregion

        #region Usuario

        public virtual DbSet<Conta> Conta { get; set; }

        #endregion

        public GCACContext()
        {
        }

        public GCACContext(DbContextOptions<GCACContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Pessoa

            modelBuilder.Entity<Cadastro>(entity =>
            {
                entity.HasIndex(e => e.CNPJ)
                    .IsUnique()
                    .HasDatabaseName("IX_Cadastro_CNPJ");

                entity.HasIndex(e => e.CNO)
                    .IsUnique()
                    .HasDatabaseName("IX_Cadastro_CNO");

                entity.HasIndex(e => e.CPF)
                    .IsUnique()
                    .HasDatabaseName("IX_Cadastro_CPF");

                entity.HasIndex(e => e.CAEPF)
                    .IsUnique()
                    .HasDatabaseName("IX_Cadastro_CAEPF");

                //entity.HasOne(d => d.CadastroNavigation)
                //    .WithMany(p => p.InverseCadastroNavigation)
                //    .HasForeignKey(d => d.CadastroId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Cadastro_Cadastro");

                //entity.HasOne(d => d.Estado)
                //    .WithMany(p => p.Cadastro)
                //    .HasForeignKey(d => d.EstadoId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Cadastro_Estado");

                entity.HasOne(d => d.Funcao)
                    .WithMany(p => p.Cadastro)
                    .HasForeignKey(d => d.FuncaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cadastro_Funcao");

                entity.HasOne(d => d.GrauEntidade)
                    .WithMany(p => p.Cadastro)
                    .HasForeignKey(d => d.GrauEntidadeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cadastro_GrauEntidade");

                entity.HasOne(d => d.Grupo)
                    .WithMany(p => p.Cadastro)
                    .HasForeignKey(d => d.GrupoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cadastro_Grupo");

                //entity.HasOne(d => d.Municipio)
                //    .WithMany(p => p.Cadastro)
                //    .HasForeignKey(d => d.MunicipioId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Cadastro_Municipio");

                entity.HasOne(d => d.RepresentanteLegal)
                    .WithMany(p => p.Cadastro)
                    .HasForeignKey(d => d.RepresentanteLegalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cadastro_RepresentanteLegal");

                entity.HasOne(d => d.Tipo)
                    .WithMany(p => p.Cadastro)
                    .HasForeignKey(d => d.TipoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cadastro_Tipo");
            });

            modelBuilder.Entity<CadastroContato>(entity =>
            {
                entity.HasKey(e => new { e.CadastroId, e.ContatoId })
                    .HasName("PK_CadastroContato_CadastroId_ContatoId");

                entity.HasOne(d => d.Cadastro)
                    .WithMany(p => p.CadastroContato)
                    .HasForeignKey(d => d.CadastroId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CadastroContato_Cadastro");

                entity.HasOne(d => d.ContatoNavigation)
                    .WithMany(p => p.CadastroContato)
                    .HasForeignKey(d => d.ContatoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CadastroContato_Contato");
            });

            modelBuilder.Entity<CadastroMunicipio>(entity =>
            {
                entity.HasKey(e => new { e.CadastroId, e.MunicipioId })
                    .HasName("PK_CadastroMunicipio_CadastroId_MunicipioId");

                //entity.HasOne(d => d.Cadastro)
                //    .WithMany(p => p.CadastroMunicipio)
                //    .HasForeignKey(d => d.CadastroId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_CadastroMunicipio_Cadastro");

                //entity.HasOne(d => d.Municipio)
                //    .WithMany(p => p.CadastroMunicipio)
                //    .HasForeignKey(d => d.MunicipioId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_CadastroMunicipio_Municipio");
            });

            modelBuilder.Entity<Contato>(entity =>
            {
                entity.HasIndex(e => e.Descricao)
                    .IsUnique();
            });

            modelBuilder.Entity<Funcao>(entity =>
            {
                entity.HasIndex(e => e.Descricao)
                    .IsUnique()
                    .HasDatabaseName("IX_Funcao_Descricao");
            });

            modelBuilder.Entity<GrauEntidade>(entity =>
            {
                entity.HasIndex(e => e.Descricao)
                    .IsUnique()
                    .HasDatabaseName("IX_GrauEntidade_Descricao");
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.HasIndex(e => e.Descricao)
                    .IsUnique()
                    .HasDatabaseName("IX_Grupo_Descricao");
            });

            modelBuilder.Entity<RepresentanteLegal>(entity =>
            {
                entity.HasIndex(e => e.Descricao)
                    .IsUnique()
                    .HasDatabaseName("IX_RepresentanteLegal_Descricao");
            });

            modelBuilder.Entity<Tipo>(entity =>
            {
                entity.HasIndex(e => e.Descricao)
                    .IsUnique()
                    .HasDatabaseName("IX_Tipo_Descricao");
            });

            #endregion

            #region InstrumentoColetivo

            modelBuilder.Entity<Documento>(entity =>
            {
            });

            //modelBuilder.Entity<EntidadeSindical>(entity =>
            //{
            //    entity.HasKey(e => new { e.Id })
            //        .HasName("PK_DocumentoMediadorHTML_Id");
            //});

            modelBuilder.Entity<DocumentoCategoria>(entity =>
            {
                entity.HasKey(e => new { e.DocumentoId, e.CategoriaId })
                    .HasName("PK_DocumentoCategoria_DocumentoId_CategoriaId");

                //entity.HasOne(d => d.Documento)
                //    .WithMany(p => p.DocumentoCategoria)
                //    .HasForeignKey(d => d.DocumentoId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_DocumentoCategoria_Documento");
            });

            modelBuilder.Entity<DocumentoEntidadeSindical>(entity =>
            {
                entity.HasKey(e => new { e.DocumentoId, e.EntidadeSindicalId })
                    .HasName("PK_InstrumentoColetivo.DocumentoEntidadeSindical_DocumentoId_EntidadeSindicalId");

                //entity.HasOne(d => d.DocumentoMediadorHTML)
                //    .WithMany(p => p.DocumentoEntidadeSindical)
                //    .HasForeignKey(d => d.DocumentoId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_InstrumentoColetivo.DocumentoEntidadeSindical_InstrumentoColetivo.DocumentoMediadorHTML");
            });

            modelBuilder.Entity<DocumentoRepresentante>(entity =>
            {
                entity.HasKey(e => new { e.DocumentoId, e.CadastroId })
                    .HasName("PK_DocumentoRepresentante_DocumentoId_PessoaCadastroId");

                //entity.HasOne(d => d.Cadastro)
                //    .WithMany(p => p.DocumentoRepresentante)
                //    .HasForeignKey(d => d.CadastroId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_DocumentoRepresentante_Cadastro");

                //entity.HasOne(d => d.Documento)
                //    .WithMany(p => p.DocumentoRepresentante)
                //    .HasForeignKey(d => d.DocumentoId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_DocumentoRepresentante_Documento");
            });

            modelBuilder.Entity<DocumentoRepresentanteLegal>(entity =>
            {
                entity.HasKey(e => new { e.DocumentoId, e.CadastroId })
                    .HasName("PK_DocumentoRepresentanteLegal_DocumentoId_CadastroId");

                //entity.HasOne(d => d.Cadastro)
                //    .WithMany(p => p.DocumentoRepresentanteLegal)
                //    .HasForeignKey(d => d.CadastroId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_DocumentoRepresentanteLegal_Cadastro");

                //entity.HasOne(d => d.Documento)
                //    .WithMany(p => p.DocumentoRepresentanteLegal)
                //    .HasForeignKey(d => d.DocumentoId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_DocumentoRepresentanteLegal_Documento");
            });

            //modelBuilder.Entity<EntidadeSindical>(entity =>
            //{
            //    entity.HasIndex(e => e.CNPJ)
            //        .IsUnique()
            //        .HasName("IX_Cadastro_CNPJ");

            //    //entity.HasOne(d => d.Estado)
            //    //    .WithMany(p => p.EntidadeSindical)
            //    //    .HasForeignKey(d => d.EstadoId)
            //    //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    //    .HasConstraintName("FK_Cadastro_Estado");

            //    //entity.HasOne(d => d.Municipio)
            //    //    .WithMany(p => p.EntidadeSindical)
            //    //    .HasForeignKey(d => d.MunicipioId)
            //    //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    //    .HasConstraintName("FK_Cadastro_Municipio");
            //});

            #endregion

            #region Usuario

            modelBuilder.Entity<Conta>(entity =>
            {
                entity
                    .HasKey(e => e.Id)
                    .HasName("PK_Usuario.Conta_Id");
                
                entity
                    .HasIndex(e => e.Email)
                    .IsUnique()
                    .HasDatabaseName("IX_Usuario.Conta_Email");
            });

            #endregion

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}