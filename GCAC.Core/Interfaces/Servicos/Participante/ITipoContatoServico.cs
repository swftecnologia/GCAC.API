using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Entidades.Participante;

namespace GCAC.Core.Interfaces.Servicos.Participante
{
    /// <summary>
    /// Interface de serviço para a entidade TipoContato
    /// </summary>
    public interface ITipoContatoServico
    {
        /// <summary>
        /// Seleciona todos os tipos de contato do participante
        /// </summary>
        /// <returns>Lista de tipos de contato do participante</returns>
        Task<IEnumerable<TipoContato>> SelecionarTodos();

        /// <summary>
        /// Seleciona um tipo de contato do participante pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único do tipo de contato do participante</param>
        /// <returns>Registro do tipo de contato do participante solicitado</returns>
        Task<TipoContato> SelecionarPorId(long id);

        /// <summary>
        /// Cria um novo tipo de contato do participante
        /// </summary>
        /// <param name="item">Novo tipo de contato do participante a ser criado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Inserir(TipoContato item);

        /// <summary>
        /// Atualiza um tipo de contato do participante
        /// </summary>
        /// <param name="item">Tipo de contato do participante a ser atualizado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Atualizar(TipoContato item);

        /// <summary>
        /// Exclui um tipo de contato do participante
        /// </summary>
        /// <param name="item">Tipo de contato do participante a ser excluído</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Excluir(TipoContato item);

        /// <summary>
        /// Verifica se o tipo de contato do participante existe por descrição
        /// </summary>
        /// <param name="descricao">Descrição do tipo de contato do participante</param>
        /// <returns>Valor indicando se o tipo de contato do participante existe ou não</returns>
        Task<bool> ExistePorDescricao(string descricao);

        /// <summary>
        /// Verifica se o tipo de contato do participante existe por descrição para um identificador diferente do tipo de contato do participante a ser alterada
        /// </summary>
        /// <param name="id">Identificador único do tipo de contato do participante</param>
        /// <param name="descricao">Descrição do tipo de contato do participante</param>
        /// <returns>Valor indicando se o tipo de contato do participante existe ou não</returns>
        Task<bool> ExistePorDescricao(string descricao, long id);
    }
}