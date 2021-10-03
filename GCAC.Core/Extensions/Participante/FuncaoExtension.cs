using GCAC.Core.Entidades.Participante;
using GCAC.Core.DTOs.Participante;

namespace GCAC.Core.Extensions.Participante
{
    /// <summary>
    /// Métodos extensivos da entidade Funcao
    /// </summary>
    public static class FuncaoExtension
    {
        /// <summary>
        /// Converte o DTO FuncaoDTO na entidade Funcao
        /// </summary>
        /// <param name="item">Função do participante a ser convertida</param>
        /// <returns></returns>
        public static Funcao AsEntitie(this FuncaoDTO item)
        {
            return new Funcao
            {
                Id = item.Id == null ? 0 : (long)item.Id,
                Descricao = item.Descricao
            };
        }

        /// <summary>
        /// Converte a entidade Funcao no DTO FuncaoDTO
        /// </summary>
        /// <param name="item">Função do participante a ser convertida</param>
        /// <returns></returns>
        public static FuncaoDTO AsDTO(this Funcao item)
        {
            return new FuncaoDTO
            {
                Id = item.Id,
                Descricao = item.Descricao
            };
        }
    }
}