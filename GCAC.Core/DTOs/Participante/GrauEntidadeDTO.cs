namespace GCAC.Core.DTOs.Participante
{
    /// <summary>
    /// Entidade para representar um grau de entidade do participante
    /// </summary>
    public record GrauEntidadeDTO
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public GrauEntidadeDTO()
        {
        }

        /// <summary>
        /// Identificador único do grau de entidade do participante (PK)
        /// </summary>
        public long? Id { get; init; }

        /// <summary>
        /// Descrição do grau de entidade do participante
        /// </summary>
        public string Descricao { get; init; }
    }
}