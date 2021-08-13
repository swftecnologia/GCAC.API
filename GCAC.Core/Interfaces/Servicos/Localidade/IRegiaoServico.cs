using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Entidades.Localidade;

namespace GCAC.Core.Interfaces.Servicos.Localidade
{
    /// <summary>
    /// Interface de serviço para a entidade Regiao
    /// </summary>
    public interface IRegiaoServico
    {
        /// <summary>
        /// Seleciona todos as regiões
        /// </summary>
        /// <returns>Lista de regiões</returns>
        Task<IEnumerable<Regiao>> SelecionarTodos();

        /// <summary>
        /// Seleciona uma região pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único da região</param>
        /// <returns>Registro da região solicitada</returns>
        Task<Regiao> SelecionarPorId(long id);

        /// <summary>
        /// Cria uma nova região
        /// </summary>
        /// <param name="item">Nova região a ser criada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Inserir(Regiao item);

        /// <summary>
        /// Atualiza uma região
        /// </summary>
        /// <param name="item">Região a ser atualizada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Atualizar(Regiao item);

        /// <summary>
        /// Exclui uma região
        /// </summary>
        /// <param name="item">Região a ser excluída</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Excluir(Regiao item);

        /// <summary>
        /// Verifica se a região existe por descrição
        /// </summary>
        /// <param name="descricao">Descrição da região</param>
        /// <returns>Valor indicando se a região existe ou não</returns>
        Task<bool> ExistePorDescricao(string descricao);

        /// <summary>
        /// Verifica se a região existe por descrição para um identificador diferente da região a ser alterada
        /// </summary>
        /// <param name="id">Identificador único da região</param>
        /// <param name="descricao">Descrição da região</param>
        /// <returns>Valor indicando se a região existe ou não</returns>
        Task<bool> ExistePorDescricao(string descricao, long id);
    }
}