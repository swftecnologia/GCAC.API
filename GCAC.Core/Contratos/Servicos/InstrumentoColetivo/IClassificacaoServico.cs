using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Entidades.InstrumentoColetivo;

namespace GCAC.Core.Interfaces.Servicos.InstrumentoColetivo
{
    /// <summary>
    /// Interface de serviço para a entidade Classificacao
    /// </summary>
    public interface IClassificacaoServico
    {
        /// <summary>
        /// Seleciona todos as classificações
        /// </summary>
        /// <returns>Lista de classificações</returns>
        Task<IEnumerable<Classificacao>> SelecionarTodos();

        /// <summary>
        /// Seleciona uma classificação pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único da classificação</param>
        /// <returns>Registro da classificação solicitada</returns>
        Task<Classificacao> SelecionarPorId(long id);

        /// <summary>
        /// Cria uma nova classificação
        /// </summary>
        /// <param name="item">Nova classificação a ser criada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Inserir(Classificacao item);

        /// <summary>
        /// Atualiza uma classificação
        /// </summary>
        /// <param name="item">Classificação a ser atualizada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Atualizar(Classificacao item);

        /// <summary>
        /// Exclui uma classificação
        /// </summary>
        /// <param name="item">Classificação a ser excluída</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Excluir(Classificacao item);

        /// <summary>
        /// Verifica se a classificação existe por descrição
        /// </summary>
        /// <param name="descricao">Descrição da classificação</param>
        /// <returns>Valor indicando se a classificação existe ou não</returns>
        Task<bool> ExistePorDescricao(string descricao);

        /// <summary>
        /// Verifica se a classificação existe por descrição para um identificador diferente da classificação a ser alterada
        /// </summary>
        /// <param name="id">Identificador único da classificação</param>
        /// <param name="descricao">Descrição da classificação</param>
        /// <returns>Valor indicando se a classificação existe ou não</returns>
        Task<bool> ExistePorDescricao(string descricao, long id);
    }
}