using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GCAC.API.Areas.InstrumentoColetivo.Entities
{
    [Table("DocumentoMediadorHTML", Schema = "InstrumentoColetivo")]
    public partial class DocumentoMediadorHTML
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string NumeroSolicitacao { get; set; }

        [Required]
        public string Conteudo { get; set; }

        public string Ano { get; set; }

        //[InverseProperty(property: "DocumentoMediadorHTML")]
        //public virtual ICollection<DocumentoEntidadeSindical> DocumentoEntidadeSindical { get; set; }
    }
}