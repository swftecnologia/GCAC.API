using GCAC.Core.Entidades.Participante;
using GCAC.Core.DTOs.Participante;

namespace GCAC.Core.Extensions.Participante
{
    /// <summary>
    /// Métodos extensivos da entidade TipoPessoa
    /// </summary>
    public static class TipoPessoaExtension
    {
        /// <summary>
        /// Converte o DTO TipoPessoaDTO na entidade TipoPessoa
        /// </summary>
        /// <param name="item">Tipo de pessoa do participante a ser convertida</param>
        /// <returns></returns>
        public static TipoPessoa AsEntitie(this TipoPessoaDTO item)
        {
            return new TipoPessoa
            {
                Id = item.Id == null ? 0 : (long)item.Id,
                Descricao = item.Descricao
            };
        }

        /// <summary>
        /// Converte a entidade TipoPessoa no DTO TipoPessoaDTO
        /// </summary>
        /// <param name="item">Tipo de pessoa do participante a ser convertida</param>
        /// <returns></returns>
        public static TipoPessoaDTO AsDTO(this TipoPessoa item)
        {
            return new TipoPessoaDTO
            {
                Id = item.Id,
                Descricao = item.Descricao
            };
        }
    }
}