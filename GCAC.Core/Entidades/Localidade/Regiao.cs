namespace GCAC.Core.Entidades.Localidade
{
    /// <summary>
    /// Entidade para representar uma região
    /// </summary>
    public record Regiao
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public Regiao()
        {
        }

        /// <summary>
        /// Identificador único da região (PK)
        /// </summary>
        public long Id { get; init; }

        /// <summary>
        /// Descrição da região
        /// </summary>
        public string Descricao { get; init; }
    }
}