namespace GCAC.Core.DTOs.Participante
{
    /// <summary>
    /// Entidade para representar um tipo de pessoa do participante
    /// </summary>
    public record TipoPessoaDTO
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public TipoPessoaDTO()
        {
        }

        /// <summary>
        /// Identificador único do tipo de pessoa do participante (PK)
        /// </summary>
        public long? Id { get; init; }

        /// <summary>
        /// Descrição do tipo de pessoa do participante
        /// </summary>
        public string Descricao { get; init; }
    }
}