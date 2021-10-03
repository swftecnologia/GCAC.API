using System.Threading.Tasks;
using GCAC.Core.Entidades.Participante;

namespace GCAC.Core.Contratos.Repositorios.Participante
{
    /// <summary>
    /// Interface de repositório para a entidade Funcao
    /// </summary>
    public interface IFuncaoRepositorio : IBaseRepositorio<Funcao>
    {
        /// <summary>
        /// Verifica se a função do participante existe por descrição
        /// </summary>
        /// <param name="descricao">Descrição da função do participante</param>
        /// <returns>Valor indicando se a função do participante existe ou não</returns>
        Task<bool> ExistePorDescricao(string descricao);

        /// <summary>
        /// Verifica se a função do participante existe por descrição para um identificador diferente da função do participante a ser alterada
        /// </summary>
        /// <param name="id">Identificador único da função do participante</param>
        /// <param name="descricao">Descrição da função do participante</param>
        /// <returns>Valor indicando se a função do participante existe ou não</returns>
        Task<bool> ExistePorDescricao(string descricao, long id);
    }
}