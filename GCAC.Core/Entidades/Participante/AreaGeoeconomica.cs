using System.Collections.Generic;

namespace GCAC.Core.Entidades.Participante
{
    /// <summary>
    /// Entidade para representar uma área geoeconômica do participante
    /// </summary>
    public record AreaGeoeconomica : BaseEntidade
    {
        /// <summary>
        /// Construtor da entidade área geoeconômica do participante
        /// </summary>
        public AreaGeoeconomica()
        {
        }

        /// <summary>
        /// Descrição da área geoeconômica do participante
        /// </summary>
        public string Descricao { get; init; }

        /// <summary>
        /// Relacionamento entre área geoeconômica do participante e participante
        /// </summary>
        public virtual ICollection<Participante> Participantes { get; init; }
    }
}