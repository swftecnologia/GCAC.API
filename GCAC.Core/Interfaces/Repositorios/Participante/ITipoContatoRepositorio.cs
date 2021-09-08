using System.Threading.Tasks;
using GCAC.Core.Entidades.Participante;

namespace GCAC.Core.Interfaces.Repositorios.Participante
{
    /// <summary>
    /// Interface de repositório para a entidade TipoContato
    /// </summary>
    public interface ITipoContatoRepositorio : IBaseRepositorio<TipoContato>
    {
        /// <summary>
        /// Verifica se o tipo de contato do participante existe por descrição
        /// </summary>
        /// <param name="descricao">Descrição do tipo de contato do participante</param>
        /// <returns>Valor indicando se o tipo de contato do participante existe ou não</returns>
        Task<bool> ExistePorDescricao(string descricao);

        /// <summary>
        /// Verifica se o tipo de contato do participante existe por descrição para um identificador diferente do tipo de contato do participante a ser alterado
        /// </summary>
        /// <param name="id">Identificador único do tipo de contato do participante</param>
        /// <param name="descricao">Descrição do tipo de contato do participante</param>
        /// <returns>Valor indicando se o tipo de contato do participante existe ou não</returns>
        Task<bool> ExistePorDescricao(string descricao, long id);
    }
}