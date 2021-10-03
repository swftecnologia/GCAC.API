namespace GCAC.Core.DTOs.Participante
{
    /// <summary>
    /// Entidade para representar um grupo do participante
    /// </summary>
    public record GrupoDTO
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public GrupoDTO()
        {
        }

        /// <summary>
        /// Identificador único do grupo do participante (PK)
        /// </summary>
        public long? Id { get; init; }

        /// <summary>
        /// Descrição do grupo do participante
        /// </summary>
        public string Descricao { get; init; }
    }
}