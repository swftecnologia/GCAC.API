namespace GCAC.Core.Entidades.InstrumentoColetivo
{
    /// <summary>
    /// Entidade para representar uma classificação
    /// </summary>
    public record Classificacao
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public Classificacao()
        {
        }

        /// <summary>
        /// Identificador único da classificação (PK)
        /// </summary>
        public long Id { get; init; }

        /// <summary>
        /// Descrição da classificação
        /// </summary>
        public string Descricao { get; init; }
    }
}