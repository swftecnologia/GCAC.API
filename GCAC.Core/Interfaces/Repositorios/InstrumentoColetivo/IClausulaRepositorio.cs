using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Entidades.InstrumentoColetivo;

namespace GCAC.Core.Interfaces.Repositorios.InstrumentoColetivo
{
    /// <summary>
    /// Interface de repositório para a entidade Clausula
    /// </summary>
    public interface IClausulaRepositorio
    {
        /// <summary>
        /// Seleciona todas as cláusulas
        /// </summary>
        /// <returns>Lista de cláusulas</returns>
        Task<IEnumerable<Clausula>> SelecionarTodos();

        /// <summary>
        /// Seleciona uma cláusula pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único da cláusula</param>
        /// <returns>Registro da cláusula solicitada</returns>
        Task<Clausula> SelecionarPorId(long id);

        /// <summary>
        /// Seleciona todos as cláusulas pertencentes a um sub-grupo da cláusula
        /// </summary>
        /// <param name="id">Identificador único do sub-grupo da cláusula</param>
        /// <returns>Lista de cláusulas pertencentes a um sub-grupo da cláusula</returns>
        Task<IEnumerable<Clausula>> SelecionarPorClausulaSubGrupo(long id);

        /// <summary>
        /// Cria uma nova cláusula
        /// </summary>
        /// <param name="item">Nova cláusula a ser criada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Inserir(Clausula item);

        /// <summary>
        /// Atualiza uma cláusula
        /// </summary>
        /// <param name="item">Cláusula a ser atualizada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Atualizar(Clausula item);

        /// <summary>
        /// Exclui uma cláusula
        /// </summary>
        /// <param name="item">Cláusula a ser excluída</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Excluir(Clausula item);

        /// <summary>
        /// Verifica se a cláusula existe por título
        /// </summary>
        /// <param name="titulo">Título da cláusula</param>
        /// <returns>Valor indicando se a cláusula existe ou não</returns>
        Task<bool> ExistePorTitulo(string titulo);

        /// <summary>
        /// Verifica se a cláusula existe por título para um identificador diferente da cláusula a ser alterada
        /// </summary>
        /// <param name="id">Identificador único da cláusula</param>
        /// <param name="titulo">Título da cláusula</param>
        /// <returns>Valor indicando se a cláusula existe ou não</returns>
        Task<bool> ExistePorTitulo(string titulo, long id);
    }
}