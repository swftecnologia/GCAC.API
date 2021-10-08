using Microsoft.EntityFrameworkCore;
using GCAC.API.Areas.InstrumentoColetivo.Entities;
using Audit.EntityFramework;

namespace GCAC.API.Data
{
    public partial class GCACContext : AuditDbContext
    {
        #region Instrumento Coletivo

        public virtual DbSet<DocumentoMediadorHTML> DocumentoMediadorHTML { get; set; }
        public virtual DbSet<DocumentoEntidadeSindical> DocumentoEntidadeSindical { get; set; }
        public virtual DbSet<DocumentoCategoria> DocumentoCategoria { get; set; }
        public virtual DbSet<DocumentoRepresentante> DocumentoRepresentante { get; set; }
        public virtual DbSet<DocumentoRepresentanteLegal> DocumentoRepresentanteLegal { get; set; }

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
            #region InstrumentoColetivo

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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}