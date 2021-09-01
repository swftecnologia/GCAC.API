namespace GCAC.Core.Entidades.Participante
{
    /// <summary>
    /// Entidade para representar um contato pertencente a um participante
    /// </summary>
    public record Contato
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public Contato()
        {
        }

        /// <summary>
        /// Identificador único do contato do participante (PK)
        /// </summary>
        public long Id { get; init; }

        /// <summary>
        /// Identificador único do participante
        /// </summary>
        public long ParticipanteId { get; init; }

        /// <summary>
        /// Participante que possui o contato
        /// </summary>
        public Participante Participante { get; init; }

        /// <summary>
        /// Identificador único do tipo de contato do participante
        /// </summary>
        public long TipoContatoId { get; init; }

        /// <summary>
        /// Tipo de contato do participante
        /// </summary>
        public TipoContato TipoContato { get; init; }

        /// <summary>
        /// Contato do participante
        /// </summary>
        public string ContatoParticipante { get; init; }
    }
}