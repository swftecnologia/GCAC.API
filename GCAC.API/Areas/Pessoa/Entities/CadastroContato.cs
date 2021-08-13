using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GCAC.API.Areas.Pessoa.Entities
{
    [Table("CadastroContato", Schema = "Pessoa")]
    public partial class CadastroContato
    {
        [Key]
        public long CadastroId { get; set; }
        
        [Key]
        public long ContatoId { get; set; }

        [Required(ErrorMessage = "O Contato é obrigatório.")]
        [StringLength(maximumLength: 100, ErrorMessage = "O Contato deve conter de {2} a {1} caracteres.", MinimumLength = 2)]
        public string Contato { get; set; }

        [ForeignKey(nameof(CadastroId))]
        [InverseProperty("CadastroContato")]
        public virtual Cadastro Cadastro { get; set; }
        
        [ForeignKey(nameof(ContatoId))]
        [InverseProperty("CadastroContato")]
        public virtual Contato ContatoNavigation { get; set; }
    }
}