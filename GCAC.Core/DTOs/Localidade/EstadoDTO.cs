namespace GCAC.Core.DTOs.Localidade
{ 
    /// <summary>
    /// DTO para representar um novo estado
    /// </summary>
    public record EstadoDTO
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public EstadoDTO()
        {
        }

        /// <summary>
        /// Identificador único do estado (PK)
        /// </summary>
        public long? Id { get; init; }

        /// <summary>
        /// Sigla do estado
        /// </summary>
        public string Sigla { get; init; }

        /// <summary>
        /// Nome do estado
        /// </summary>
        public string Nome { get; init; }

        /// <summary>
        /// Identificador único do país ao qual o estado pertence
        /// </summary>
        public long? PaisId { get; init; }
    }
}