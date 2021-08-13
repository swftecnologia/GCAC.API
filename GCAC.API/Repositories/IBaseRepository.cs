using System.Collections.Generic;
using System.Threading.Tasks;

namespace GCAC.API.Repositories
{
    /// <summary>
    /// Interface de repositório genérico para operações de CRUD das entidades
    /// </summary>
    /// <typeparam name="T">Entidade</typeparam>
    public interface IBaseRepository<T> where T : class
    {
        /// <summary>
        /// Lista todos os registros
        /// </summary>
        /// <returns>Lista de registros da entidade solicitada</returns>
        Task<IEnumerable<T>> ListarTodos();

        /// <summary>
        /// Lista todos os registros de acordo com os critérios de pesquisa informados
        /// </summary>
        /// <param name="criterios">Condições de pesquisa</param>
        /// <returns>Lista de registros da entidade solicitada</returns>
        Task<IEnumerable<T>> ListarComCriterios(List<(string Propriedade, object Valor, bool Igual, string Operador)> criterios);

        /// <summary>
        /// Seleciona um registro pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único</param>
        /// <returns>Registro da entidade solicitada</returns>
        Task<T> SelecionarPorId(long id);

        /// <summary>
        /// Insere um registro
        /// </summary>
        /// <param name="item">Entidade</param>
        /// <returns>Quantidade de registros afetados pela operação para a entidade informada</returns>
        Task<int> Inserir(T item);

        /// <summary>
        /// Atualiza um registro
        /// </summary>
        /// <param name="item">Entidade</param>
        /// <returns>Quantidade de registros afetados pela operação para a entidade informada</returns>
        Task<int> Atualizar(T item);

        /// <summary>
        /// Exclui um registro
        /// </summary>
        /// <param name="item">Entidade</param>
        /// <returns>Quantidade de registros afetados pela operação para a entidade informada</returns>
        Task<int> Excluir(T item);

        /// <summary>
        /// Checa se a entidade existe
        /// </summary>
        /// <param name="id">Identificador único</param>
        /// <returns>Booleano indicando se a entidade existe</returns>
        Task<bool> Existe(long id);

        /// <summary>
        /// Checa se a entidade existe de acordo com os critérios de pesquisa informados
        /// </summary>
        /// <param name="criterios">Condições de pesquisa</param>
        /// <returns>Booleano indicando se a entidade existe</returns>
        Task<bool> ExisteComCriterios(List<(string Propriedade, object Valor, bool Igual, string Operador)> criterios);
    }
}