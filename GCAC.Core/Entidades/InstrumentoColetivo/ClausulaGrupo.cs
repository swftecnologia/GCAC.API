namespace GCAC.Core.Entidades.InstrumentoColetivo
{
    /// <summary>
    /// Entidade para representar um grupo da cláusula
    /// </summary>
    public record ClausulaGrupo
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public ClausulaGrupo()
        {
        }

        /// <summary>
        /// Identificador único do grupo da cláusula (PK)
        /// </summary>
        public long Id { get; init; }

        /// <summary>
        /// Ordem do grupo da cláusula
        /// </summary>
        public int Ordem { get; init; }

        /// <summary>
        /// Descrição do grupo da cláusula
        /// </summary>
        public string Descricao { get; init; }
    }
}