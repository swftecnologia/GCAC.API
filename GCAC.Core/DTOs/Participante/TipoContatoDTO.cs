namespace GCAC.Core.DTOs.Participante
{
    /// <summary>
    /// Entidade para representar um tipo de contato do participante
    /// </summary>
    public record TipoContatoDTO
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public TipoContatoDTO()
        {
        }

        /// <summary>
        /// Identificador único do tipo de contato do participante (PK)
        /// </summary>
        public long? Id { get; init; }

        /// <summary>
        /// Descrição do tipo de contato do participante
        /// </summary>
        public string Descricao { get; init; }
    }
}