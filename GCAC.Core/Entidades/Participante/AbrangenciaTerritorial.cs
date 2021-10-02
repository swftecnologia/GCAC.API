using GCAC.Core.Entidades.Localidade;

namespace GCAC.Core.Entidades.Participante
{
    /// <summary>
    /// Entidade para representar uma abrangência territorial do participante
    /// </summary>
    public record  AbrangenciaTerritorial
    {
        /// <summary>
        /// Construtor da entidade abrangência territorial do participante
        /// </summary>
        public AbrangenciaTerritorial()
        {
        }

        /// <summary>
        /// Identificador único do participante
        /// </summary>
        public long? ParticipanteId { get; init; }

        /// <summary>
        /// Participante
        /// </summary>
        public Participante Participante { get; init; }

        /// <summary>
        /// Identificador único do município do participante
        /// </summary>
        public long MunicipioId { get; init; }

        /// <summary>
        /// Município do participante
        /// </summary>
        public Municipio Municipio { get; init; }
    }
}