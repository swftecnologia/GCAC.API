namespace GCAC.Core.Entidades.Participante
{
    /// <summary>
    /// Entidade para representar um tipo de pessoa do participante
    /// </summary>
    public record TipoPessoa
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public TipoPessoa()
        {
        }

        /// <summary>
        /// Identificador único do tipo de pessoa do participante (PK)
        /// </summary>
        public long Id { get; init; }

        /// <summary>
        /// Descrição do tipo de pessoa do participante
        /// </summary>
        public string Descricao { get; init; }
    }
}