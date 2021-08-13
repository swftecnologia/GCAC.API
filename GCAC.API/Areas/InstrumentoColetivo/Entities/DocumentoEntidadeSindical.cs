using GCAC.Core.Entidades.InstrumentoColetivo;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GCAC.API.Areas.InstrumentoColetivo.Entities
{
    [Table("DocumentoEntidadeSindical", Schema = "InstrumentoColetivo")]
    public partial class DocumentoEntidadeSindical
    {
        [Key]
        public long DocumentoId { get; set; }
        
        [Key]
        public long EntidadeSindicalId { get; set; }

        //[ForeignKey(nameof(DocumentoId))]
        //[InverseProperty("DocumentoEntidadeSindical")]
        //public virtual DocumentoMediadorHTML DocumentoMediadorHTML { get; set; }

        //[ForeignKey(nameof(EntidadeSindicalId))]
        //[InverseProperty("DocumentoEntidadeSindical")]
        //public virtual EntidadeSindical EntidadeSindical { get; set; }
    }
}