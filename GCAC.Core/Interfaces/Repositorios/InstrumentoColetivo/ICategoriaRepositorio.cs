using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Entidades.InstrumentoColetivo;

namespace GCAC.Core.Interfaces.Repositorios.InstrumentoColetivo
{
    /// <summary>
    /// Interface de repositório para a entidade Categoria
    /// </summary>
    public interface ICategoriaRepositorio
    {
        /// <summary>
        /// Seleciona todos as categorias
        /// </summary>
        /// <returns>Lista de categorias</returns>
        Task<IEnumerable<Categoria>> SelecionarTodos();

        /// <summary>
        /// Seleciona uma categoria pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único da categoria</param>
        /// <returns>Registro da categoria solicitada</returns>
        Task<Categoria> SelecionarPorId(long id);

        /// <summary>
        /// Cria uma nova categoria
        /// </summary>
        /// <param name="item">Nova categoria a ser criada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Inserir(Categoria item);

        /// <summary>
        /// Atualiza uma categoria
        /// </summary>
        /// <param name="item">Categoria a ser atualizada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Atualizar(Categoria item);

        /// <summary>
        /// Exclui uma categoria
        /// </summary>
        /// <param name="item">Categoria a ser excluída</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Excluir(Categoria item);

        /// <summary>
        /// Verifica se a categoria existe por descrição
        /// </summary>
        /// <param name="descricao">Descrição da categoria</param>
        /// <returns>Valor indicando se a categoria existe ou não</returns>
        Task<bool> ExistePorDescricao(string descricao);

        /// <summary>
        /// Verifica se a categoria existe por descrição para um identificador diferente da categoria a ser alterada
        /// </summary>
        /// <param name="id">Identificador único da categoria</param>
        /// <param name="descricao">Descrição da categoria</param>
        /// <returns>Valor indicando se a categoria existe ou não</returns>
        Task<bool> ExistePorDescricao(string descricao, long id);
    }
}