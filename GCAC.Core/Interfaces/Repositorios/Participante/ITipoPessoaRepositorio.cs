using System.Threading.Tasks;
using GCAC.Core.Entidades.Participante;

namespace GCAC.Core.Interfaces.Repositorios.Participante
{
    /// <summary>
    /// Interface de repositório para a entidade TipoPessoa
    /// </summary>
    public interface ITipoPessoaRepositorio : IBaseRepositorio<TipoPessoa>
    {
        /// <summary>
        /// Verifica se o tipo de pessoa do participante existe por descrição
        /// </summary>
        /// <param name="descricao">Descrição do tipo de pessoa do participante</param>
        /// <returns>Valor indicando se o tipo de pessoa do participante existe ou não</returns>
        Task<bool> ExistePorDescricao(string descricao);

        /// <summary>
        /// Verifica se o tipo de pessoa do participante existe por descrição para um identificador diferente do tipo de pessoa do participante a ser alterado
        /// </summary>
        /// <param name="id">Identificador único do tipo de pessoa do participante</param>
        /// <param name="descricao">Descrição do tipo de pessoa do participante</param>
        /// <returns>Valor indicando se o tipo de pessoa do participante existe ou não</returns>
        Task<bool> ExistePorDescricao(string descricao, long id);
    }
}