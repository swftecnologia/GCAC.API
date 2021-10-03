namespace GCAC.Core.DTOs.Participante
{
    /// <summary>
    /// Entidade para representar uma função do participante
    /// </summary>
    public record FuncaoDTO
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public FuncaoDTO()
        {
        }

        /// <summary>
        /// Identificador único da função do participante (PK)
        /// </summary>
        public long? Id { get; init; }

        /// <summary>
        /// Descrição da função do participante
        /// </summary>
        public string Descricao { get; init; }
    }
}