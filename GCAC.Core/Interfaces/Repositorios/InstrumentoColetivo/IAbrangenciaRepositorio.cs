using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Entidades.InstrumentoColetivo;

namespace GCAC.Core.Interfaces.Repositorios.InstrumentoColetivo
{
    /// <summary>
    /// Interface de repositório para a entidade Abrangencia
    /// </summary>
    public interface IAbrangenciaRepositorio
    {
        /// <summary>
        /// Seleciona todos as abrangências
        /// </summary>
        /// <returns>Lista de abrangências</returns>
        Task<IEnumerable<Abrangencia>> SelecionarTodos();

        /// <summary>
        /// Seleciona uma abrangência pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único da abrangência</param>
        /// <returns>Registro da abrangência solicitada</returns>
        Task<Abrangencia> SelecionarPorId(long id);

        /// <summary>
        /// Cria uma nova abrangência
        /// </summary>
        /// <param name="item">Nova abrangência a ser criada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Inserir(Abrangencia item);

        /// <summary>
        /// Atualiza uma abrangência
        /// </summary>
        /// <param name="item">Abrangência a ser atualizada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Atualizar(Abrangencia item);

        /// <summary>
        /// Exclui uma abrangência
        /// </summary>
        /// <param name="item">Abrangência a ser excluída</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Excluir(Abrangencia item);

        /// <summary>
        /// Verifica se a abrangência existe por descrição
        /// </summary>
        /// <param name="descricao">Descrição da abrangência</param>
        /// <returns>Valor indicando se a abrangência existe ou não</returns>
        Task<bool> ExistePorDescricao(string descricao);

        /// <summary>
        /// Verifica se a abrangência existe por descrição para um identificador diferente da abrangência a ser alterada
        /// </summary>
        /// <param name="id">Identificador único da abrangência</param>
        /// <param name="descricao">Descrição da abrangência</param>
        /// <returns>Valor indicando se a abrangência existe ou não</returns>
        Task<bool> ExistePorDescricao(string descricao, long id);
    }
}