using System;

namespace GCAC.Core.Entidades.Log
{
    /// <summary>
    /// Entidade para representar log de operações realizadas no banco de dados
    /// </summary>
    public record Auditoria
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public Auditoria()
        {
        }

        /// <summary>
        /// Identificação da auditoria (PK)
        /// </summary>
        public long Id { get; init; }

        /// <summary>
        /// Dados da auditoria
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