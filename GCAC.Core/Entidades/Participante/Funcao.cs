namespace GCAC.Core.Entidades.Participante
{
    /// <summary>
    /// Entidade para representar uma função do participante
    /// </summary>
    public record Funcao
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public Funcao()
        {
        }

        /// <summary>
        /// Identificador único da função do participante (PK)
        /// </summary>
        public long Id { get; init; }

        /// <summary>
        /// Descrição da função do participante
        /// </summary>
        public string Descricao { get; init; }
    }
}