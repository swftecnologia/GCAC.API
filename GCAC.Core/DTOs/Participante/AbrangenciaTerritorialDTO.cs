namespace GCAC.Core.DTOs.Participante
{
    /// <summary>
    /// DTO para representar uma abrangência territorial
    /// </summary>
    public record AbrangenciaTerritorialDTO
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public AbrangenciaTerritorialDTO()
        {
        }

        /// <summary>
        /// Participante da abrangência territorial
        /// </summary>
        public long? ParticipanteId { get; init; }

        /// <summary>
        /// Município da abrangência territorial
        /// </summary>
        public long? MunicipioId { get; init; }
    }
}