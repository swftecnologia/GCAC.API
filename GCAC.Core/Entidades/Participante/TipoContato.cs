using System.Collections.Generic;

namespace GCAC.Core.Entidades.Participante
{
    /// <summary>
    /// Entidade para representar um tipo de contato do participante
    /// </summary>
    public record TipoContato : BaseEntidade
    {
        /// <summary>
        /// Construtor da entidade tipo de contato do participante
        /// </summary>
        public TipoContato()
        {
        }

        /// <summary>
        /// Descrição do tipo de contato do participante
        /// </summary>
        public string Descricao { get; init; }

        // <summary>
        /// Relacionamento entre tipo de contato e contato do participante
        // </summary>
        public virtual ICollection<Contato> Contatos { get; init; }
    }
}