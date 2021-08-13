namespace GCAC.Core.DTOs.Localidade
{
    /// <summary>
    /// DTO para representar uma região
    /// </summary>
    public record RegiaoDTO
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public RegiaoDTO()
        {
        }

        /// <summary>
        /// Identificador único da região (PK)
        /// </summary>
        public long? Id { get; init; }

        /// <summary>
        /// Descrição da região
        /// </summary>
        public string Descricao { get; init; }
    }
}