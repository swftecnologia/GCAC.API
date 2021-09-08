using System.Collections.Generic;

namespace GCAC.Core.Entidades.Participante
{
    /// <summary>
    /// Entidade para representar um tipo de pessoa do participante
    /// </summary>
    public record TipoPessoa : BaseEntidade
    {
        /// <summary>
        /// Construtor da entidade tipo de pessoa do participante
        /// </summary>
        public TipoPessoa()
        {
        }

        /// <summary>
        /// Descrição do tipo de pessoa do participante
        /// </summary>
        public string Descricao { get; init; }

        /// <summary>
        /// Relacionamento entre tipo de pessoa do participante e participante
        /// </summary>
        public virtual ICollection<Participante> Participantes { get; init; }
    }
}