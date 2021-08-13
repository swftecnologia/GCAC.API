using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Entidades.Localidade;

namespace GCAC.Core.Interfaces.Repositorios.Localidade
{
    /// <summary>
    /// Interface de repositório para a entidade Pais
    /// </summary>
    public interface IPaisRepositorio
    {
        /// <summary>
        /// Seleciona todos os países
        /// </summary>
        /// <returns>Lista de países</returns>
        Task<IEnumerable<Pais>> SelecionarTodos();

        /// <summary>
        /// Seleciona um país pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único do país</param>
        /// <returns>Registro do país solicitado</returns>
        Task<Pais> SelecionarPorId(long id);

        /// <summary>
        /// Cria um novo país
        /// </summary>
        /// <param name="item">Novo país a ser criado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Inserir(Pais item);

        /// <summary>
        /// Atualiza um país
        /// </summary>
        /// <param name="item">País a ser atualizado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Atualizar(Pais item);

        /// <summary>
        /// Exclui um país
        /// </summary>
        /// <param name="item">País a ser excluído</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Excluir(Pais item);

        /// <summary>
        /// Verifica se o país existe por nome
        /// </summary>
        /// <param name="nome">Nome do país</param>
        /// <returns>Valor indicando se o país existe ou não</returns>
        Task<bool> ExistePorNome(string nome);

        /// <summary>
        /// Verifica se o país existe por nome para um identificador diferente do país a ser alterado
        /// </summary>
        /// <param name="id">Identificador único do país</param>
        /// <param name="nome">Nome do país</param>
        /// <returns>Valor indicando se o país existe ou não</returns>
        Task<bool> ExistePorNome(string nome, long id);
    }
}