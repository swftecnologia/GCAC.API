using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GCAC.API.Areas.Usuarios.Contas.Entities
{
    [Table("Conta", Schema = "Usuario")]
    public record Conta
    {
        [Key]
        public int Id { get; init; }

        [Required]
        public bool Ativo { get; set; }

        [Required]
        public DateTime DataAtualizacao { get; init; }

        [Required]
        public DateTime DataCriacao { get; init; }

        public DateTime? DataExpiracaoAlteracaoSenha { get; init; }

        [Required]
        public DateTime DataExpiracaoTokenAtivacao { get; init; }

        [Required]
        [StringLength(320)]
        public string Email { get; init; }

        [Required]
        public bool EmailConfirmado { get; init; }

        [Required]
        [StringLength(150)]
        public string Nome { get; init; }

        [Required]
        [StringLength(128)]
        public string Senha { get; init; }

        [Required]
        [StringLength(300)]
        public string Sobrenome { get; init; }

        [Required]
        public Guid TokenAtivacao { get; init; }


        public Guid? TokenAlteracaoSenha { get; init; }

        [Required]
        [StringLength(320)]
        public string Usuario { get; init; }
    }
}