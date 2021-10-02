namespace GCAC.Core.DTOs.Participante
{
    /// <summary>
    /// Entidade para representar um representante legal do participante
    /// </summary>
    public record RepresentanteLegalDTO
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public RepresentanteLegalDTO()
        {
        }

        /// <summary>
        /// Identificador único do representante legal do participante (PK)
        /// </summary>
        public long? Id { get; init; }

        /// <summary>
        /// Descrição do representante legal do participante
        /// </summary>
        public string Descricao { get; init; }
    }
}