namespace GCAC.Core.DTOs.Participante
{
    /// <summary>
    /// DTO para representar uma abrangência
    /// </summary>
    public record AbrangenciaDTO
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public AbrangenciaDTO()
        {
        }

        /// <summary>
        /// Identificador único da abrangência
        /// </summary>
        public long? Id { get; init; }

        /// <summary>
        /// Descrição da abrangência
        /// </summary>
        public string Descricao { get; init; }
    }
}