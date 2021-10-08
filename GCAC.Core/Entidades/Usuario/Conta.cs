using System;

namespace GCAC.Core.Entidades.Usuario
{
    /// <summary>
    /// Entidade para representar uma conta de usuário
    /// </summary>
    public record Conta : BaseEntidade
    {
        /// <summary>
        /// Construtor da entidade conta
        /// </summary>
        public Conta()
        {
        }

        /// <summary>
        /// Indica se a conta está ativa
        /// </summary>
        public bool Ativo { get; set; }

        /// <summary>
        /// Data de expiração de alteração da senha da conta
        /// </summary>
        public DateTime? DataExpiracaoAlteracaoSenha { get; init; }

        /// <summary>
        /// Data de expiração do token de ativação
        /// </summary>
        public DateTime DataExpiracaoTokenAtivacao { get; set; }

        /// <summary>
        /// E-mail cadastrado para a conta
        /// </summary>
        public string Email { get; init; }

        /// <summary>
        /// Indica se o e-mail cadastrado para a conta foi confirmado
        /// </summary>
        public bool EmailConfirmado { get; init; }

        /// <summary>
        /// Nome do usuário da conta
        /// </summary>
        public string Nome { get; init; }

        /// <summary>
        /// Senha da conta
        /// </summary>
        public string Senha { get; init; }

        /// <summary>
        /// Sobrenome do usuário da conta
        /// </summary>
        public string Sobrenome { get; init; }

        /// <summary>
        /// Token de ativação da conta
        /// </summary>
        public Guid TokenAtivacao { get; set; }

        /// <summary>
        /// Token de alteração da senha da conta
        /// </summary>
        public Guid? TokenAlteracaoSenha { get; init; }
    }
}
