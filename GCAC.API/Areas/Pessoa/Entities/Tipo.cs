using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GCAC.API.Areas.Pessoa.Entities
{
    [Table("Tipo", Schema = "Pessoa")]
    public partial class Tipo
    {
        public Tipo()
        {
            Cadastro = new HashSet<Cadastro>();
        }

        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "A Descrição é obrigatória.")]
        [StringLength(maximumLength: 50, ErrorMessage = "A Descrição deve conter de {2} a {1} caracteres.", MinimumLength = 2)]
        public string Descricao { get; set; }

        [InverseProperty("Tipo")]
        public virtual ICollection<Cadastro> Cadastro { get; set; }
    }
}