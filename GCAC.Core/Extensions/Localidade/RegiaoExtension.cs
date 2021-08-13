using GCAC.Core.Entidades.Localidade;
using GCAC.Core.DTOs.Localidade;

namespace GCAC.Core.Extensions.Localidade
{
    /// <summary>
    /// Métodos extensivos da entidade Regiao
    /// </summary>
    public static class RegiaoExtension
    {
        /// <summary>
        /// Converte o DTO RegiaoDTO na entidade Regiao
        /// </summary>
        /// <param name="item">Região a ser convertida</param>
        /// <returns></returns>
        public static Regiao AsEntitie(this RegiaoDTO item)
        {
            return new Regiao
            {
                Id = item.Id == null ? 0 : (long)item.Id,
                Descricao = item.Descricao
            };
        }

        /// <summary>
        /// Converte a entidade Regiao no DTO RegiaoDTO
        /// </summary>
        /// <param name="item">Região a ser convertida</param>
        /// <returns></returns>
        public static RegiaoDTO AsDTO(this Regiao item)
        {
            return new RegiaoDTO
            {
                Id = item.Id,
                Descricao = item.Descricao
            };
        }
    }
}