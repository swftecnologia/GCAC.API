namespace GCAC.Core.Entidades.InstrumentoColetivo
{
    /// <summary>
    /// Entidade para representar uma abrangência
    /// </summary>
    public record Abrangencia
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public Abrangencia()
        {
        }

        /// <summary>
        /// Identificador único da abrangência (PK)
        /// </summary>
        public long Id { get; init; }

        /// <summary>
        /// Descrição da abrangência
        /// </summary>
        public string Descricao { get; init; }
    }
}