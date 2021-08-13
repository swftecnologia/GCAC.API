namespace GCAC.Core.DTOs.InstrumentoColetivo
{
    /// <summary>
    /// DTO para representar um sub-grupo da cláusula
    /// </summary>
    public record ClausulaSubGrupoDTO
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public ClausulaSubGrupoDTO()
        {
        }

        /// <summary>
        /// Identificador único do sub-grupo da cláusula (PK)
        /// </summary>
        public long? Id { get; init; }

        /// <summary>
        /// Ordem do sub-grupo da cláusula
        /// </summary>
        public int Ordem { get; init; }

        /// <summary>
        /// Descricao do sub-grupo da cláusula
        /// </summary>
        public string Descricao { get; init; }

        /// <summary>
        /// Identificador único do grupo ao qual o sub-grupo da cláusula pertence
        /// </summary>
        public long ClausulaGrupoId { get; init; }
    }
}