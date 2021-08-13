namespace GCAC.Core.DTOs.InstrumentoColetivo
{
    /// <summary>
    /// DTO para representar uma categoria
    /// </summary>
    public record CategoriaDTO
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public CategoriaDTO()
        {
        }

        /// <summary>
        /// Identificador único da categoria (PK)
        /// </summary>
        public long? Id { get; init; }

        /// <summary>
        /// Descrição da categoria
        /// </summary>
        public string Descricao { get; init; }
    }
}