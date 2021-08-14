namespace GCAC.Core.Entidades.Participante
{
    /// <summary>
    /// Entidade para representar um grau de entidade do participante
    /// </summary>
    public record GrauEntidade
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public GrauEntidade()
        {
        }

        /// <summary>
        /// Identificador único do grau de entidade do participante (PK)
        /// </summary>
        public long Id { get; init; }

        /// <summary>
        /// Descrição do grau de entidade do participante
        /// </summary>
        public string Descricao { get; init; }
    }
}