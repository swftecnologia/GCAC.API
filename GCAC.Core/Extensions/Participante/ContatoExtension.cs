using GCAC.Core.Entidades.Participante;
using GCAC.Core.DTOs.Participante;

namespace GCAC.Core.Extensions.Participante
{
    /// <summary>
    /// Métodos extensivos da entidade Contato
    /// </summary>
    public static class ContatoExtension
    {
        /// <summary>
        /// Converte o DTO ContatoDTO na entidade Contato
        /// </summary>
        /// <param name="item">Contato do participante a ser convertido</param>
        /// <returns></returns>
        public static Contato AsEntitie(this ContatoDTO item)
        {
            return new Contato
            {
                ParticipanteId = item.ParticipanteId == null ? 0 : (long)item.ParticipanteId,
                TipoContatoId = item.TipoContatoId == null ? 0 : (long)item.TipoContatoId,
                ContatoParticipante = item.ContatoParticipante
            };
        }

        /// <summary>
        /// Converte a entidade Contato no DTO ContatoDTO
        /// </summary>
        /// <param name="item">Contato do participante a ser convertida</param>
        /// <returns></returns>
        public static ContatoDTO AsDTO(this Contato item)
        {
            return new ContatoDTO
            {
                ParticipanteId = item.ParticipanteId,
                TipoContatoId = item.TipoContatoId,
                ContatoParticipante = item.ContatoParticipante
            };
        }
    }
}