using GCAC.Core.Entidades.Participante;
using GCAC.Core.DTOs.Participante;

namespace GCAC.Core.Extensions.Participante
{
    /// <summary>
    /// Métodos extensivos da entidade Grupo
    /// </summary>
    public static class GrupoExtension
    {
        /// <summary>
        /// Converte o DTO GrupoDTO na entidade Grupo
        /// </summary>
        /// <param name="item">Grupo do participante a ser convertido</param>
        /// <returns></returns>
        public static Grupo AsEntitie(this GrupoDTO item)
        {
            return new Grupo
            {
                Id = item.Id == null ? 0 : (long)item.Id,
                Descricao = item.Descricao
            };
        }

        /// <summary>
        /// Converte a entidade Grupo no DTO GrupoDTO
        /// </summary>
        /// <param name="item">Grupo do participante a ser convertido</param>
        /// <returns></returns>
        public static GrupoDTO AsDTO(this Grupo item)
        {
            return new GrupoDTO
            {
                Id = item.Id,
                Descricao = item.Descricao
            };
        }
    }
}