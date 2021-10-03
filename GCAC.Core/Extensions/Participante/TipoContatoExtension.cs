using GCAC.Core.Entidades.Participante;
using GCAC.Core.DTOs.Participante;

namespace GCAC.Core.Extensions.Participante
{
    /// <summary>
    /// Métodos extensivos da entidade TipoContato
    /// </summary>
    public static class TipoContatoExtension
    {
        /// <summary>
        /// Converte o DTO TipoContatoDTO na entidade TipoContato
        /// </summary>
        /// <param name="item">Tipo de contato do participante a ser convertida</param>
        /// <returns></returns>
        public static TipoContato AsEntitie(this TipoContatoDTO item)
        {
            return new TipoContato
            {
                Id = item.Id == null ? 0 : (long)item.Id,
                Descricao = item.Descricao
            };
        }

        /// <summary>
        /// Converte a entidade TipoContato no DTO TipoContatoDTO
        /// </summary>
        /// <param name="item">Tipo de contato do participante a ser convertida</param>
        /// <returns></returns>
        public static TipoContatoDTO AsDTO(this TipoContato item)
        {
            return new TipoContatoDTO
            {
                Id = item.Id,
                Descricao = item.Descricao
            };
        }
    }
}