using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Entidades.Participante;

namespace GCAC.Core.Contratos.Repositorios.Participante
{
    /// <summary>
    /// Interface de repositório para a entidade Contato
    /// </summary>
    public interface IContatoRepositorio : IBaseRepositorio<Contato>
    {
        /// <summary>
        /// Seleciona todos os contatos pertencentes a um participante
        /// </summary>
        /// <param name="id">Identificador único do participante</param>
        /// <returns>Lista de contatos pertencentes a um participante</returns>
        Task<IEnumerable<Contato>> SelecionarPorParticipante(long id);

        /// <summary>
        /// Verifica se o contato do participante existe
        /// </summary>
        /// <param name="idParticipante">Identificador único do participante</param>
        /// <param name="idTipoContato">Identificador único do tipo de contato do participante</param>
        /// <param name="contatoParticipante">Contato do participante</param>
        /// <returns>Valor indicando se o contato do participante existe ou não</returns>
        Task<bool> ExistePorContatoParticipante(long idParticipante, long idTipoContato, string contatoParticipante);

        /// <summary>
        /// Verifica se o contato do participante existe para um identificador diferente do contato do participante a ser alterado
        /// </summary>
        /// <param name="idParticipante">Identificador único do participante</param>
        /// <param name="idTipoContato">Identificador único do tipo de contato do participante</param>
        /// <param name="id">Identificador único do contato do participante</param>
        /// <param name="contatoParticipante">Contato do participante</param>
        /// <returns>Valor indicando se o contato do participante existe ou não</returns>
        Task<bool> ExistePorContatoParticipante(long idParticipante, long idTipoContato, string contatoParticipante, long id);
    }
}