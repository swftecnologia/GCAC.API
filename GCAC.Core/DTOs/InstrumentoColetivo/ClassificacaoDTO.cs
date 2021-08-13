namespace GCAC.Core.DTOs.InstrumentoColetivo
{
    /// <summary>
    /// DTO para representar uma classificação
    /// </summary>
    public record ClassificacaoDTO
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public ClassificacaoDTO()
        {
        }

        /// <summary>
        /// Identificador único da classificação (PK)
        /// </summary>
        public long? Id { get; init; }

        /// <summary>
        /// Descrição da classificação
        /// </summary>
        public string Descricao { get; init; }
    }
}