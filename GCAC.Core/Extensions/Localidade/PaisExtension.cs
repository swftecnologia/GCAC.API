using GCAC.Core.Entidades.Localidade;
using GCAC.Core.DTOs.Localidade;

namespace GCAC.Core.Extensions.Localidade
{
    /// <summary>
    /// Métodos extensivos da entidade Pais
    /// </summary>
    public static class PaisExtension
    {
        /// <summary>
        /// Converte o DTO PaisDTO na entidade Pais
        /// </summary>
        /// <param name="item">País a ser convertido</param>
        /// <returns></returns>
        public static Pais AsEntitie(this PaisDTO item)
        {
            return new Pais
            {
                Id = item.Id == null ? 0 : (long)item.Id,
                Sigla = item.Sigla,
                Nome = item.Nome
            };
        }

        /// <summary>
        /// Converte a entidade Pais no DTO PaisDTO
        /// </summary>
        /// <param name="item">País a ser convertido</param>
        /// <returns></returns>
        public static PaisDTO AsDTO(this Pais item)
        {
            return new PaisDTO
            {
                Id = item.Id,
                Sigla = item.Sigla,
                Nome = item.Nome
            };
        }
    }
}