using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GCAC.API.Areas.Pessoa.Entities;

namespace GCAC.API.Areas.InstrumentoColetivo.Entities
{
    [Table("DocumentoRepresentante", Schema = "InstrumentoColetivo")]
    public partial class DocumentoRepresentante
    {
        [Key]
        public long DocumentoId { get; set; }
        
        [Key]
        public long CadastroId { get; set; }

        //[ForeignKey(nameof(DocumentoId))]
        //[InverseProperty("DocumentoRepresentante")]
        //public virtual Documento Documento { get; set; }

        //[ForeignKey(nameof(CadastroId))]
        //[InverseProperty("DocumentoRepresentante")]
        //public virtual Cadastro Cadastro { get; set; }
    }
}