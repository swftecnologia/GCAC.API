using System.Threading.Tasks;
using GCAC.Core.Entidades.Participante;

namespace GCAC.Core.Interfaces.Repositorios.Participante
{
    /// <summary>
    /// Interface de repositório para a entidade Grupo
    /// </summary>
    public interface IGrupoRepositorio : IBaseRepositorio<Grupo>
    {
        /// <summary>
        /// Verifica se o grupo do participante existe por descrição
        /// </summary>
        /// <param name="descricao">Descrição do grupo do participante</param>
        /// <returns>Valor indicando se o grupo do participante existe ou não</returns>
        Task<bool> ExistePorDescricao(string descricao);

        /// <summary>
        /// Verifica se o grupo do participante existe por descrição para um identificador diferente do grupo do participante a ser alterado
        /// </summary>
        /// <param name="id">Identificador único do grupo do participante</param>
        /// <param name="descricao">Descrição do grupo do participante</param>
        /// <returns>Valor indicando se o grupo do participante existe ou não</returns>
        Task<bool> ExistePorDescricao(string descricao, long id);
    }
}