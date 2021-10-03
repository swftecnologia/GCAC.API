using System.Collections.Generic;
using System.Threading.Tasks;

namespace GCAC.Core.Contratos.Servicos
{
    /// <summary>
    /// Interface de serviço base
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IBaseServico<TEntity> where TEntity : class
    {
        /// <summary>
        /// Seleciona todos os registros
        /// </summary>
        /// <returns>Lista de registros</returns>
        Task<IEnumerable<TEntity>> SelecionarTodos();

        /// <summary>
        /// Seleciona um registro pelo seu identificador único (PK)
        /// </summary>
        /// <param name="id">Identificador único</param>
        /// <returns>Registro solicitado</returns>
        Task<TEntity> SelecionarPorId(long id);

        /// <summary>
        /// Insere um novo registro
        /// </summary>
        /// <param name="item">Novo registro a ser inserido</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Inserir(TEntity item);

        /// <summary>
        /// Atualiza um registro existente
        /// </summary>
        /// <param name="item">Registro a ser atualizado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Atualizar(TEntity item);

        /// <summary>
        /// Exclui um registro existente
        /// </summary>
        /// <param name="item">Registro a ser excluído</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Excluir(TEntity item);
    }
}