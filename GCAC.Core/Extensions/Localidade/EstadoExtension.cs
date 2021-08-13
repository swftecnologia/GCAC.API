using GCAC.Core.Entidades.Localidade;
using GCAC.Core.DTOs.Localidade;

namespace GCAC.Core.Extensions.Localidade
{
    /// <summary>
    /// Métodos extensivos da entidade Estado
    /// </summary>
    public static class EstadoExtension
    {
        /// <summary>
        /// Converte o DTO EstadoDTO na entidade Estado
        /// </summary>
        /// <param name="item">Estado a ser convertido</param>
        /// <returns></returns>
        public static Estado AsEntitie(this EstadoDTO item)
        {
            return new Estado
            {
                Id = item.Id == null ? 0 : (long)item.Id,
                Sigla = item.Sigla,
                Nome = item.Nome,
                PaisId = item.PaisId == null ? 0 : (long)item.PaisId
            };
        }

        /// <summary>
        /// Converte a entidade Estado no DTO EstadoDTO
        /// </summary>
        /// <param name="item">Estado a ser convertido</param>
        /// <returns></returns>
        public static EstadoDTO AsDTO(this Estado item)
        {
            return new EstadoDTO
            {
                Id = item.Id,
                Sigla = item.Sigla,
                Nome = item.Nome,
                PaisId = item.PaisId
            };
        }
    }
}