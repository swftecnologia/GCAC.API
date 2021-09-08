using System.Threading.Tasks;
using GCAC.Core.Entidades.Participante;

namespace GCAC.Core.Interfaces.Repositorios.Participante
{
    /// <summary>
    /// Interface de repositório para a entidade RepresentanteLegal
    /// </summary>
    public interface IRepresentanteLegalRepositorio : IBaseRepositorio<RepresentanteLegal>
    {
        /// <summary>
        /// Verifica se o representante legal do participante existe por descrição
        /// </summary>
        /// <param name="descricao">Descrição do representante legal do participante</param>
        /// <returns>Valor indicando se o representante legal do participante existe ou não</returns>
        Task<bool> ExistePorDescricao(string descricao);

        /// <summary>
        /// Verifica se o representante legal do participante existe por descrição para um identificador diferente do representante legal do participante a ser alterado
        /// </summary>
        /// <param name="id">Identificador único do representante legal do participante</param>
        /// <param name="descricao">Descrição do representante legal do participante</param>
        /// <returns>Valor indicando se o representante legal do participante existe ou não</returns>
        Task<bool> ExistePorDescricao(string descricao, long id);
    }
}