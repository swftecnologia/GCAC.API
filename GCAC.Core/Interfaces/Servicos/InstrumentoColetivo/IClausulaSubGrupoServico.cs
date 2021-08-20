using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Entidades.InstrumentoColetivo;

namespace GCAC.Core.Interfaces.Servicos.InstrumentoColetivo
{
    /// <summary>
    /// Interface de serviço para a entidade ClausulaSubGrupo
    /// </summary>
    public interface IClausulaSubGrupoServico
    {
        /// <summary>
        /// Seleciona todos os sub-grupos do grupo da claúsula
        /// </summary>
        /// <returns>Lista de sub-grupos do grupo da claúsula</returns>
        Task<IEnumerable<ClausulaSubGrupo>> SelecionarTodos();

        /// <summary>
        /// Seleciona um sub-grupo do grupo da claúsula pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único do sub-grupo do grupo da claúsula</param>
        /// <returns>Registro do sub-grupo do grupo da claúsula solicitada</returns>
        Task<ClausulaSubGrupo> SelecionarPorId(long id);

        /// <summary>
        /// Seleciona todos os sub-grupos da clásula pertencentes a um grupo da cláusula
        /// </summary>
        /// <param name="id">Identificador único do grupo da cláusula</param>
        /// <returns>Lista de sub-grupos da cláusula pertencentes a um grupo da cláusula</returns>
        Task<IEnumerable<ClausulaSubGrupo>> SelecionarPorClausulaGrupo(long id);

        /// <summary>
        /// Cria um novo sub-grupo do grupo da claúsula
        /// </summary>
        /// <param name="item">Novo sub-grupo do grupo da claúsula a ser criado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Inserir(ClausulaSubGrupo item);

        /// <summary>
        /// Atualiza um sub-grupo do grupo da claúsula
        /// </summary>
        /// <param name="item">Sub-Grupo do grupo da claúsula a ser atualizado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Atualizar(ClausulaSubGrupo item);

        /// <summary>
        /// Exclui um sub-grupo do grupo da claúsula
        /// </summary>
        /// <param name="item">Sub-Grupo do grupo da claúsula a ser excluído</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Excluir(ClausulaSubGrupo item);

        /// <summary>
        /// Verifica se o sub-grupo do grupo da claúsula existe por descrição
        /// </summary>
        /// <param name="descricao">Descrição do sub-grupo do grupo da claúsula</param>
        /// <returns>Valor indicando se o sub-grupo do grupo da claúsula existe ou não</returns>
        Task<bool> ExistePorDescricao(string descricao);

        /// <summary>
        /// Verifica se o sub-grupo do grupo da claúsula existe por descrição para um identificador diferente do sub-grupo do grupo da claúsula a ser alterado
        /// </summary>
        /// <param name="id">Identificador único do sub-grupo do grupo da claúsula</param>
        /// <param name="descricao">Descrição do sub-grupo do grupo da claúsula</param>
        /// <returns>Valor indicando se o sub-grupo do grupo da claúsula existe ou não</returns>
        Task<bool> ExistePorDescricao(string descricao, long id);
    }
}