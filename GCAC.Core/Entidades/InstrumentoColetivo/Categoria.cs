namespace GCAC.Core.Entidades.InstrumentoColetivo
{
    /// <summary>
    /// Entidade para representar uma categoria
    /// </summary>
    public record Categoria
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public Categoria()
        {
        }

        /// <summary>
        /// Identificador único da categoria (PK)
        /// </summary>
        public long Id { get; init; }

        /// <summary>
        /// Descrição da categoria
        /// </summary>
        public string Descricao { get; init; }
    }
}