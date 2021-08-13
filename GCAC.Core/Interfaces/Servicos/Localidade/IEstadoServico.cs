using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Entidades.Localidade;

namespace GCAC.Core.Interfaces.Servicos.Localidade
{
    /// <summary>
    /// Interface de serviço para a entidade Estado
    /// </summary>
    public interface IEstadoServico
    {
        /// <summary>
        /// Seleciona todos os estados
        /// </summary>
        /// <returns>Lista de estados</returns>
        Task<IEnumerable<Estado>> SelecionarTodos();

        /// <summary>
        /// Seleciona um estado pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único do estado</param>
        /// <returns>Registro do estado solicitado</returns>
        Task<Estado> SelecionarPorId(long id);

        /// <summary>
        /// Seleciona todos os estados pertencentes a um país
        /// </summary>
        /// <param name="id">Identificador único do país</param>
        /// <returns>Lista de estados pertencentes a um país</returns>
        Task<IEnumerable<Estado>> SelecionarPorPais(long id);

        /// <summary>
        /// Cria um novo estado
        /// </summary>
        /// <param name="item">Novo estado a ser criado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Inserir(Estado item);

        /// <summary>
        /// Atualiza um estado
        /// </summary>
        /// <param name="item">Estado a ser atualizado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Atualizar(Estado item);

        /// <summary>
        /// Exclui um estado
        /// </summary>
        /// <param name="item">Estado a ser excluído</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Excluir(Estado item);

        /// <summary>
        /// Verifica se o estado existe por nome
        /// </summary>
        /// <param name="nome">Nome do estado</param>
        /// <returns>Valor indicando se o estado existe ou não</returns>
        Task<bool> ExistePorNome(string nome);

        /// <summary>
        /// Verifica se o estado existe por nome para um identificador diferente do estado a ser alterado
        /// </summary>
        /// <param name="id">Identificador único do estado</param>
        /// <param name="nome">Nome do estado</param>
        /// <returns>Valor indicando se o estado existe ou não</returns>
        Task<bool> ExistePorNome(string nome, long id);
    }
}