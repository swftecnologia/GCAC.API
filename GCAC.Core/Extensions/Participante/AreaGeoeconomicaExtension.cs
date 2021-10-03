using GCAC.Core.Entidades.Participante;
using GCAC.Core.DTOs.Participante;

namespace GCAC.Core.Extensions.Participante
{
    /// <summary>
    /// Métodos extensivos da entidade AreaGeoeconomica
    /// </summary>
    public static class AreaGeoeconomicaExtension
    {
        /// <summary>
        /// Converte o DTO AreaGeoeconomicaDTO na entidade AreaGeoeconomica
        /// </summary>
        /// <param name="item">Área Geoeconômica a ser convertida</param>
        /// <returns></returns>
        public static AreaGeoeconomica AsEntitie(this AreaGeoeconomicaDTO item)
        {
            return new AreaGeoeconomica
            {
                Id = item.Id == null ? 0 : (long)item.Id,
                Descricao = item.Descricao
            };
        }

        /// <summary>
        /// Converte a entidade AreaGeoeconomica no DTO AreaGeoeconomicaDTO
        /// </summary>
        /// <param name="item">Área Geoeconômica a ser convertida</param>
        /// <returns></returns>
        public static AreaGeoeconomicaDTO AsDTO(this AreaGeoeconomica item)
        {
            return new AreaGeoeconomicaDTO
            {
                Id = item.Id,
                Descricao = item.Descricao
            };
        }
    }
}