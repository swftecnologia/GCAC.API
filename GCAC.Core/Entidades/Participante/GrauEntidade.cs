using System.Collections.Generic;

namespace GCAC.Core.Entidades.Participante
{
    /// <summary>
    /// Entidade para representar um grau de entidade do participante
    /// </summary>
    public record GrauEntidade : BaseEntidade
    {
        /// <summary>
        /// Construtor da entidade grau da entidade do participante
        /// </summary>
        public GrauEntidade()
        {
        }

        /// <summary>
        /// Descrição do grau de entidade do participante
        /// </summary>
        public string Descricao { get; init; }

        // <summary>
        /// Relacionamento entre grau de entidade do participante e participante
        // </summary>
        public virtual ICollection<Participante> Participantes { get; init; }
    }
}