using GCAC.Core.Entidades.InstrumentoColetivo;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GCAC.API.Areas.InstrumentoColetivo.Entities
{
    [Table("DocumentoCategoria", Schema = "InstrumentoColetivo")]
    public partial class DocumentoCategoria
    {
        [Key]
        public long DocumentoId { get; set; }
        
        [Key]
        public long CategoriaId { get; set; }

        //[ForeignKey(nameof(DocumentoId))]
        //[InverseProperty("DocumentoCategoria")]
        //public virtual Documento Documento { get; set; }

        //[ForeignKey(nameof(CategoriaId))]
        //[InverseProperty("DocumentoCategoria")]
        //public virtual Categoria Categoria { get; set; }
    }
}