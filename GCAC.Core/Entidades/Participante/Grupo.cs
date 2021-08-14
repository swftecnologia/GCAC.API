namespace GCAC.Core.Entidades.Participante
{
    /// <summary>
    /// Entidade para representar um grupo do participante
    /// </summary>
    public record Grupo
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public Grupo()
        {
        }

        /// <summary>
        /// Identificador único do grupo do participante (PK)
        /// </summary>
        public long Id { get; init; }

        /// <summary>
        /// Descrição do grupo do participante
        /// </summary>
        public string Descricao { get; init; }
    }
}