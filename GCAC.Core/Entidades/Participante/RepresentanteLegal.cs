using System.Collections.Generic;

namespace GCAC.Core.Entidades.Participante
{
    /// <summary>
    /// Entidade para representar um representante legal do participante
    /// </summary>
    public record RepresentanteLegal : BaseEntidade
    {
        /// <summary>
        /// Construtor da entidade representante legal do participante
        /// </summary>
        public RepresentanteLegal()
        {
        }

        /// <summary>
        /// Descrição do representante legal do participante
        /// </summary>
        public string Descricao { get; init; }

        // <summary>
        /// Relacionamento entre representante legal do participante e participante
        // </summary>
        public virtual ICollection<Participante> Participantes { get; init; }
    }
}