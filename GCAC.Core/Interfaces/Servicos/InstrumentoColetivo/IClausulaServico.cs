using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Entidades.InstrumentoColetivo;

namespace GCAC.Core.Interfaces.Servicos.InstrumentoColetivo
{
    /// <summary>
    /// Interface de serviço para a entidade Clausula
    /// </summary>
    public interface IClausulaServico
    {
        /// <summary>
        /// Seleciona todas as claúsulas
        /// </summary>
        /// <returns>Lista de claúsulas</returns>
        Task<IEnumerable<Clausula>> SelecionarTodos();

        /// <summary>
        /// Seleciona uma claúsula pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único da claúsula</param>
        /// <returns>Registro da claúsula solicitada</returns>
        Task<Clausula> SelecionarPorId(long id);

        /// <summary>
        /// Cria uma nova claúsula
        /// </summary>
        /// <param name="item">Nova claúsula a ser criada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Inserir(Clausula item);

        /// <summary>
        /// Atualiza uma claúsula
        /// </summary>
        /// <param name="item">Claúsula a ser atualizada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Atualizar(Clausula item);

        /// <summary>
        /// Exclui uma claúsula
        /// </summary>
        /// <param name="item">Claúsula a ser excluída</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Excluir(Clausula item);

        /// <summary>
        /// Verifica se a claúsula existe por título
        /// </summary>
        /// <param name="titulo">Título da claúsula</param>
        /// <returns>Valor indicando se a claúsula existe ou não</returns>
        Task<bool> ExistePorTitulo(string titulo);

        /// <summary>
        /// Verifica se a claúsula existe por título para um identificador diferente da claúsula a ser alterada
        /// </summary>
        /// <param name="id">Identificador único da claúsula</param>
        /// <param name="titulo">Título da claúsula</param>
        /// <returns>Valor indicando se a claúsula existe ou não</returns>
        Task<bool> ExistePorTitulo(string titulo, long id);
    }
}