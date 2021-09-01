using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Entidades.Participante;

namespace GCAC.Core.Interfaces.Servicos.Participante
{
    /// <summary>
    /// Interface de serviço para a entidade Contato
    /// </summary>
    public interface IContatoServico
    {
        /// <summary>
        /// Seleciona todas os contatos do participante
        /// </summary>
        /// <returns>Lista de contatos do participante</returns>
        Task<IEnumerable<Contato>> SelecionarTodos();

        /// <summary>
        /// Seleciona um contato do participante pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único do contato do participante</param>
        /// <returns>Registro do contato do participante solicitado</returns>
        Task<Contato> SelecionarPorId(long id);

        /// <summary>
        /// Seleciona todos os contatos pertencentes a um participante
        /// </summary>
        /// <param name="id">Identificador único do participante</param>
        /// <returns>Lista de contatos pertencentes a um participante</returns>
        Task<IEnumerable<Contato>> SelecionarPorParticipante(long id);

        /// <summary>
        /// Cria um novo contato do participante
        /// </summary>
        /// <param name="item">Novo contato do participante a ser criado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Inserir(Contato item);

        /// <summary>
        /// Atualiza um contato do participante
        /// </summary>
        /// <param name="item">Contato do participante a ser atualizado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Atualizar(Contato item);

        /// <summary>
        /// Exclui um contato do participante
        /// </summary>
        /// <param name="item">Contato do participante a ser excluído</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Excluir(Contato item);

        /// <summary>
        /// Verifica se o contato do participante existe
        /// </summary>
        /// <param name="contatoParticipante">Contato do participante</param>
        /// <returns>Valor indicando se o contato do participante existe ou não</returns>
        Task<bool> ExistePorContatoParticipante(string contatoParticipante);

        /// <summary>
        /// Verifica se o contato do participante existe para um identificador diferente do contato do participante a ser alterado
        /// </summary>
        /// <param name="id">Identificador único do contato do participante</param>
        /// <param name="contatoParticipante">Contato do participante</param>
        /// <returns>Valor indicando se o contato do participante existe ou não</returns>
        Task<bool> ExistePorContatoParticipante(string contatoParticipante, long id);
    }
}