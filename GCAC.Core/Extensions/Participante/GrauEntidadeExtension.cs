using GCAC.Core.Entidades.Participante;
using GCAC.Core.DTOs.Participante;

namespace GCAC.Core.Extensions.Participante
{
    /// <summary>
    /// Métodos extensivos da entidade GrauEntidade
    /// </summary>
    public static class GrauEntidadeExtension
    {
        /// <summary>
        /// Converte o DTO GrauEntidadeDTO na entidade GrauEntidade
        /// </summary>
        /// <param name="item">Grau da entidade do participante a ser convertida</param>
        /// <returns></returns>
        public static GrauEntidade AsEntitie(this GrauEntidadeDTO item)
        {
            return new GrauEntidade
            {
                Id = item.Id == null ? 0 : (long)item.Id,
                Descricao = item.Descricao
            };
        }

        /// <summary>
        /// Converte a entidade GrauEntidade no DTO GrauEntidadeDTO
        /// </summary>
        /// <param name="item">Grau da entidade do participante a ser convertida</param>
        /// <returns></returns>
        public static GrauEntidadeDTO AsDTO(this GrauEntidade item)
        {
            return new GrauEntidadeDTO
            {
                Id = item.Id,
                Descricao = item.Descricao
            };
        }
    }
}