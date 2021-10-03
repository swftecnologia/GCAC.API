using System;

namespace GCAC.Core.Entidades.Log
{
    /// <summary>
    /// Entidade para representar log de operações com erros no banco de dados
    /// </summary>
    public record Erro
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public Erro()
        {
        }

        /// <summary>
        /// Identificação do erro (PK)
        /// </summary>
        public long Id { get; init; }

        /// <summary>
        /// Dados do erro
        /// </summary>
        public string Dados { get; set; }

        /// <summary>
        /// Usuário solicitante
        /// </summary>
        public string Usuario { get; set; }

        /// <summary>
        /// Data da solicitação
        /// </summary>
        public DateTime DataOperacao { get; set; }
    }
}