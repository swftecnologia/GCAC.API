using GCAC.Core.Entidades.InstrumentoColetivo;
using GCAC.Core.DTOs.InstrumentoColetivo;

namespace GCAC.Core.Extensions.InstrumentoColetivo
{
    /// <summary>
    /// Métodos extensivos da entidade Abrangencia
    /// </summary>
    public static class AbrangenciaExtension
    {
        /// <summary>
        /// Converte o DTO AbrangenciaDTO na entidade Abrangencia
        /// </summary>
        /// <param name="item">Abrangência a ser convertida</param>
        /// <returns></returns>
        public static Abrangencia AsEntitie(this AbrangenciaDTO item)
        {
            return new Abrangencia
            {
                Id = item.Id == null ? 0 : (long)item.Id,
                Descricao = item.Descricao
            };
        }

        /// <summary>
        /// Converte a entidade Abrangencia no DTO AbrangenciaDTO
        /// </summary>
        /// <param name="item">Abrangência a ser convertida</param>
        /// <returns></returns>
        public static AbrangenciaDTO AsDTO(this Abrangencia item)
        {
            return new AbrangenciaDTO
            {
                Id = item.Id,
                Descricao = item.Descricao
            };
        }
    }
}