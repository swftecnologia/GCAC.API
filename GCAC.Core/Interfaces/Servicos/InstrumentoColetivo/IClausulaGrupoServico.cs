using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Entidades.InstrumentoColetivo;

namespace GCAC.Core.Interfaces.Servicos.InstrumentoColetivo
{
    /// <summary>
    /// Interface de serviço para a entidade ClausulaGrupo
    /// </summary>
    public interface IClausulaGrupoServico
    {
        /// <summary>
        /// Seleciona todos os grupos da claúsula
        /// </summary>
        /// <returns>Lista de grupos da claúsula</returns>
        Task<IEnumerable<ClausulaGrupo>> SelecionarTodos();

        /// <summary>
        /// Seleciona um grupo da claúsula pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único do grupo da claúsula</param>
        /// <returns>Registro do grupo da claúsula solicitada</returns>
        Task<ClausulaGrupo> SelecionarPorId(long id);

        /// <summary>
        /// Cria um novo grupo da claúsula
        /// </summary>
        /// <param name="item">Novo grupo da claúsula a ser criado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Inserir(ClausulaGrupo item);

        /// <summary>
        /// Atualiza um grupo da claúsula
        /// </summary>
        /// <param name="item">Grupo da claúsula a ser atualizado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Atualizar(ClausulaGrupo item);

        /// <summary>
        /// Exclui um grupo da claúsula
        /// </summary>
        /// <param name="item">Grupo da claúsula a ser excluído</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Excluir(ClausulaGrupo item);

        /// <summary>
        /// Verifica se o grupo da claúsula existe por descrição
        /// </summary>
        /// <param name="descricao">Descrição do grupo da claúsula</param>
        /// <returns>Valor indicando se o grupo da claúsula existe ou não</returns>
        Task<bool> ExistePorDescricao(string descricao);

        /// <summary>
        /// Verifica se o grupo da claúsula existe por descrição para um identificador diferente do grupo da claúsula a ser alterado
        /// </summary>
        /// <param name="id">Identificador único do grupo da claúsula</param>
        /// <param name="descricao">Descrição do grupo da claúsula</param>
        /// <returns>Valor indicando se o grupo da claúsula existe ou não</returns>
        Task<bool> ExistePorDescricao(string descricao, long id);
    }
}