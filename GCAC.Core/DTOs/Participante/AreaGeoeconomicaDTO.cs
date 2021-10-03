namespace GCAC.Core.DTOs.Participante
{
    /// <summary>
    /// DTO para representar uma área geoeconômica
    /// </summary>
    public record AreaGeoeconomicaDTO
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public AreaGeoeconomicaDTO()
        {
        }

        /// <summary>
        /// Identificador único da área geoeconômica
        /// </summary>
        public long? Id { get; init; }

        /// <summary>
        /// Descrição da área geoeconômica
        /// </summary>
        public string Descricao { get; init; }
    }
}