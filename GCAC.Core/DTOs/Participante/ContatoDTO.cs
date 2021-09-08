namespace GCAC.Core.DTOs.Participante
{
    /// <summary>
    /// Entidade para representar um contato pertencente a um participante
    /// </summary>
    public record ContatoDTO
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public ContatoDTO()
        {
        }

        /// <summary>
        /// Identificador único do contato do participante (PK)
        /// </summary>
        public long? Id { get; init; }

        /// <summary>
        /// Contato do participante
        /// </summary>
        public string ContatoParticipante { get; init; }

        /// <summary>
        /// Identificador único do participante
        /// </summary>
        public long ParticipanteId { get; init; }

        /// <summary>
        /// Identificador único do tipo de contato do participante
        /// </summary>
        public long TipoContatoId { get; init; }
    }
}