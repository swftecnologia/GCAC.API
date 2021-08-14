namespace GCAC.Core.Entidades.Participante
{
    /// <summary>
    /// Entidade para representar um tipo de contato do participante
    /// </summary>
    public record TipoContato
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public TipoContato()
        {
        }

        /// <summary>
        /// Identificador único do tipo de contato do participante (PK)
        /// </summary>
        public long Id { get; init; }

        /// <summary>
        /// Descrição do tipo de contato do participante
        /// </summary>
        public string Descricao { get; init; }
    }
}