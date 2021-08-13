using System.ComponentModel.DataAnnotations;

namespace GCAC.API.Areas.Usuarios.Contas.DataTransferObjects
{
    public record ContaDTOCreate
    {
        [Required(ErrorMessage = "A Confirmação de Senha é obrigatória.")]
        [RegularExpression("[A-Za-z0-9]{6,8}", ErrorMessage = @"A Confirmação de Senha deve possuir entre 6 a 8 caracteres e apenas letras e/ou números.")]
        [Compare(nameof(Senha), ErrorMessage = "A Senha deve ser a mesma.")]
        public string ConfirmarSenha { get; init; }

        [Required(ErrorMessage = "O {0} é obrigatório.")]
        [DataType(DataType.EmailAddress)]
        [StringLength(320, MinimumLength = 3, ErrorMessage = "O {0} deve possuir entre {2} a {1} caracteres.")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "O {0} deve possuir um formato válido.")]
        public string Email { get; init; }

        [Required(ErrorMessage = "O {0} é obrigatório.")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "O {0} deve possuir entre {2} a {1} caracteres.")]
        public string Nome { get; init; }

        [Required(ErrorMessage = "A {0} é obrigatória.")]
        [RegularExpression("[A-Za-z0-9]{6,8}", ErrorMessage = @"A {0} deve possuir entre 6 a 8 caracteres e apenas letras e/ou números.")]
        public string Senha { get; init; }

        [Required(ErrorMessage = "O {0} é obrigatório.")]
        [StringLength(300, MinimumLength = 2, ErrorMessage = "O {0} deve possuir entre {2} a {1} caracteres.")]
        public string Sobrenome { get; init; }
    }
}