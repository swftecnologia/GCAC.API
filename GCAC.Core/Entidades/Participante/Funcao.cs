using System.Collections.Generic;

namespace GCAC.Core.Entidades.Participante
{
    /// <summary>
    /// Entidade para representar uma função do participante
    /// </summary>
    public record Funcao : BaseEntidade
    {
        /// <summary>
        /// Construtor da entidade função do participante
        /// </summary>
        public Funcao()
        {
        }

        /// <summary>
        /// Descrição da função do participante
        /// </summary>
        public string Descricao { get; init; }

        // <summary>
        /// Relacionamento entre função do participante e participante
        // </summary>
        public virtual ICollection<Participante> Participantes { get; init; }
    }
}