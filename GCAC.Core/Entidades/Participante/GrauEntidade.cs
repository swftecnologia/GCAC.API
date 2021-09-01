using System.Collections.Generic;

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

        // <summary>
        /// Relacionamento entre grau de entidade do participante e participante
        // </summary>
        public virtual ICollection<Participante> Participantes { get; set; }
    }
}