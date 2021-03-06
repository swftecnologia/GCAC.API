using System;

namespace GCAC.Core.Entidades.InstrumentoColetivo
{
    /// <summary>
    /// Entidade para representar uma cláusula
    /// </summary>
    public record Clausula
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public Clausula ()
        {
        }

        /// <summary>
        /// Identificador único da cláusula (PK)
        /// </summary>
        public long Id { get; init; }

        /// <summary>
        /// Vigência inicial da cláusula
        /// </summary>
        public DateTime VigenciaInicial { get; init; }

        /// <summary>
        /// Vigência final da cláusula
        /// </summary>
        public DateTime VigenciaFinal { get; init; }

        /// <summary>
        /// Vigência diferenciada da cláusula
        /// </summary>
        public bool VigenciaDiferenciada { get; init; }

        /// <summary>
        /// Título da cláusula
        /// </summary>
        public string Titulo { get; init; }

        /// <summary>
        /// Descrição da cláusula
        /// </summary>
        public string Descricao { get; init; }


        /// <summary>
        /// Identificador único do sub-grupo da cláusula ao qual a cláusula pertence
        /// </summary>
        public long ClausulaSubGrupoId { get; init; }
    }
}