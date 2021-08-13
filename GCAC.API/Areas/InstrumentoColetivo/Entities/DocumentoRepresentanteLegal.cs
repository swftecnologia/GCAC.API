using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GCAC.API.Areas.Pessoa.Entities;

namespace GCAC.API.Areas.InstrumentoColetivo.Entities
{
    [Table("DocumentoRepresentanteLegal", Schema = "InstrumentoColetivo")]
    public partial class DocumentoRepresentanteLegal
    {
        [Key]
        public long DocumentoId { get; set; }
        
        [Key]
        public long CadastroId { get; set; }

        //[ForeignKey(nameof(DocumentoId))]
        //[InverseProperty("DocumentoRepresentanteLegal")]
        //public virtual Documento Documento { get; set; }

        //[ForeignKey(nameof(CadastroId))]
        //[InverseProperty("DocumentoRepresentanteLegal")]
        //public virtual Cadastro Cadastro { get; set; }
    }
}