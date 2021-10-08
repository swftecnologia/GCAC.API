using System;

namespace GCAC.Core.DTOs.Usuario
{
    /// <summary>
    /// Entidade para representar uma conta de usuário
    /// </summary>
    public record ContaDTO
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public ContaDTO()
        {
        }

        /// <summary>
        /// Identificador único da conta
        /// </summary>
        public long? Id { get; init; }

        /// <summary>
        /// Indica se a conta está ativa
        /// </summary>
        public bool Ativo { get; init; }

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
        public string Senha { get; set; }

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
