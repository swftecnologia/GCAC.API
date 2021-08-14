namespace GCAC.Core.Entidades.Participante
{
    /// <summary>
    /// Entidade para representar um representante legal do participante
    /// </summary>
    public record RepresentanteLegal
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public RepresentanteLegal()
        {
        }

        /// <summary>
        /// Identificador único do representante legal do participante (PK)
        /// </summary>
        public long Id { get; init; }

        /// <summary>
        /// Descrição do representante legal do participante
        /// </summary>
        public string Descricao { get; init; }
    }
}