namespace GCAC.Core.Entidades.Participante
{
    /// <summary>
    /// Entidade para representar um contato do participante
    /// </summary>
    public record Contato : BaseEntidade
    {
        /// <summary>
        /// Construtor da entidade contato do participante
        /// </summary>
        public Contato()
        {
        }

        /// <summary>
        /// Valor do contato do participante
        /// </summary>
        public string ContatoParticipante { get; init; }

        /// <summary>
        /// Identificador único do participante
        /// </summary>
        public long ParticipanteId { get; init; }

        /// <summary>
        /// Participante
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
    }
}