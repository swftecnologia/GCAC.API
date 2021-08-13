using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GCAC.API.Areas.Pessoa.Entities
{
    [Table("CadastroMunicipio", Schema = "Pessoa")]
    public partial class CadastroMunicipio
    {
        [Key]
        public long CadastroId { get; set; }
        
        [Key]
        public long MunicipioId { get; set; }

        //[ForeignKey(nameof(CadastroId))]
        //[InverseProperty("CadastroMunicipio")]
        //public virtual Cadastro Cadastro { get; set; }
        
        //[ForeignKey(nameof(MunicipioId))]
        //[InverseProperty("CadastroMunicipio")]
        //public virtual Municipio Municipio { get; set; }
    }
}