using System.Collections.Generic;

namespace GCAC.Core.Entidades.Participante
{
    /// <summary>
    /// Entidade para representar uma abrangência do participante
    /// </summary>
    public record Abrangencia : BaseEntidade
    {
        /// <summary>
        /// Construtor da entidade abrangência do participante
        /// </summary>
        public Abrangencia()
        {
        }

        /// <summary>
        /// Descrição da abrangência do participante
        /// </summary>
        public string Descricao { get; init; }

        /// <summary>
        /// Relacionamento entre abrangência do participante e participante
        /// </summary>
        ///public virtual ICollection<Participante> Participantes { get; init; }

        /// <summary>
        /// Relacionamento entre abrangência do participante e participante
        /// </summary>
        public virtual Participante Participante { get; init; }
    }
}