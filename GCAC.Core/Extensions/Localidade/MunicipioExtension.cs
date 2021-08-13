using GCAC.Core.Entidades.Localidade;
using GCAC.Core.DTOs.Localidade;

namespace GCAC.Core.Extensions.Localidade
{
    /// <summary>
    /// Métodos extensivos da entidade Municipio
    /// </summary>
    public static class MunicipioExtension
    {
        /// <summary>
        /// Converte o DTO MunicipioDTO na entidade Municipio
        /// </summary>
        /// <param name="item">Município a ser convertido</param>
        /// <returns></returns>
        public static Municipio AsEntitie(this MunicipioDTO item)
        {
            return new Municipio
            {
                Id = item.Id == null ? 0 : (long)item.Id,
                Nome = item.Nome,
                EstadoId = item.EstadoId == null ? 0 : (long)item.EstadoId
            };
        }

        /// <summary>
        /// Converte a entidade Municipio no DTO MunicipioDTO
        /// </summary>
        /// <param name="item">Município a ser convertido</param>
        /// <returns></returns>
        public static MunicipioDTO AsDTO(this Municipio item)
        {
            return new MunicipioDTO
            {
                Id = item.Id,
                Nome = item.Nome,
                EstadoId = item.EstadoId
            };
        }
    }
}