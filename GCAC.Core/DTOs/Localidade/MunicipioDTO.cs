namespace GCAC.Core.DTOs.Localidade
{ 
    /// <summary>
    /// DTO para representar um novo município
    /// </summary>
    public record MunicipioDTO
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public MunicipioDTO()
        {
        }

        /// <summary>
        /// Identificador único do município (PK)
        /// </summary>
        public long? Id { get; init; }

        /// <summary>
        /// Nome do município
        /// </summary>
        public string Nome { get; init; }

        /// <summary>
        /// Identificador único do estado ao qual o município pertence
        /// </summary>
        public long? EstadoId { get; init; }
    }
}