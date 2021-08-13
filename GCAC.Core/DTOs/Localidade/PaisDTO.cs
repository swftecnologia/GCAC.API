namespace GCAC.Core.DTOs.Localidade
{ 
    /// <summary>
    /// DTO para representar um novo país
    /// </summary>
    public record PaisDTO
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public PaisDTO()
        {
        }

        /// <summary>
        /// Identificador único do país (PK)
        /// </summary>
        public long? Id { get; init; }

        /// <summary>
        /// Sigla do país
        /// </summary>
        public string Sigla { get; init; }

        /// <summary>
        /// Nome do país
        /// </summary>
        public string Nome { get; init; }
    }
}