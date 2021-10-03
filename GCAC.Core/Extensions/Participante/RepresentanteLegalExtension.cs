using GCAC.Core.Entidades.Participante;
using GCAC.Core.DTOs.Participante;

namespace GCAC.Core.Extensions.Participante
{
    /// <summary>
    /// Métodos extensivos da entidade RepresentanteLegal
    /// </summary>
    public static class RepresentanteLegalExtension
    {
        /// <summary>
        /// Converte o DTO RepresentanteLegalDTO na entidade RepresentanteLegal
        /// </summary>
        /// <param name="item">Representante legal do participante a ser convertido</param>
        /// <returns></returns>
        public static RepresentanteLegal AsEntitie(this RepresentanteLegalDTO item)
        {
            return new RepresentanteLegal
            {
                Id = item.Id == null ? 0 : (long)item.Id,
                Descricao = item.Descricao
            };
        }

        /// <summary>
        /// Converte a entidade RepresentanteLegal no DTO RepresentanteLegalDTO
        /// </summary>
        /// <param name="item">Representante legal do participante a ser convertido</param>
        /// <returns></returns>
        public static RepresentanteLegalDTO AsDTO(this RepresentanteLegal item)
        {
            return new RepresentanteLegalDTO
            {
                Id = item.Id,
                Descricao = item.Descricao
            };
        }
    }
}