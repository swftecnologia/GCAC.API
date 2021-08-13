namespace GCAC.Core.DTOs.InstrumentoColetivo
{
    /// <summary>
    /// DTO para representar um grupo da cláusula
    /// </summary>
    public record ClausulaGrupoDTO
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public ClausulaGrupoDTO()
        {
        }

        /// <summary>
        /// Identificador único do grupo da cláusula (PK)
        /// </summary>
        public long? Id { get; init; }

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