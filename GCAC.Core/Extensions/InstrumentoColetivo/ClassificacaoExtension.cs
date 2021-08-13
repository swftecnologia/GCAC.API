using GCAC.Core.Entidades.InstrumentoColetivo;
using GCAC.Core.DTOs.InstrumentoColetivo;

namespace GCAC.Core.Extensions.InstrumentoColetivo
{
    /// <summary>
    /// Métodos extensivos da entidade Classificacao
    /// </summary>
    public static class ClassificacaoExtension
    {
        /// <summary>
        /// Converte o DTO ClassificacaoDTO na entidade Classificacao
        /// </summary>
        /// <param name="item">Classificação a ser convertida</param>
        /// <returns></returns>
        public static Classificacao AsEntitie(this ClassificacaoDTO item)
        {
            return new Classificacao
            {
                Id = item.Id == null ? 0 : (long)item.Id,
                Descricao = item.Descricao
            };
        }

        /// <summary>
        /// Converte a entidade Classificacao no DTO ClassificacaoDTO
        /// </summary>
        /// <param name="item">Classificação a ser convertida</param>
        /// <returns></returns>
        public static ClassificacaoDTO AsDTO(this Classificacao item)
        {
            return new ClassificacaoDTO
            {
                Id = item.Id,
                Descricao = item.Descricao
            };
        }
    }
}