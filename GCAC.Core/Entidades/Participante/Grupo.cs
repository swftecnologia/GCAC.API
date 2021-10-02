using System.Collections.Generic;

namespace GCAC.Core.Entidades.Participante
{
    /// <summary>
    /// Entidade para representar um grupo do participante
    /// </summary>
    public record Grupo : BaseEntidade
    {
        /// <summary>
        /// Construtor da entidade grupo do participante
        /// </summary>
        public Grupo()
        {
        }

        /// <summary>
        /// Descrição do grupo do participante
        /// </summary>
        public string Descricao { get; init; }

        /// <summary>
        /// Relacionamento entre grupo do participante e participante
        /// </summary>
        public virtual ICollection<Participante> Participantes { get; init; }
    }
}