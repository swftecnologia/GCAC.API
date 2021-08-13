using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Entidades.InstrumentoColetivo;
using GCAC.Core.Interfaces.Repositorios.InstrumentoColetivo;
using GCAC.Core.Interfaces.Servicos.InstrumentoColetivo;

namespace GCAC.Core.Servicos.InstrumentoColetivo
{
    /// <summary>
    /// Serviços para a entidade Categoria
    /// </summary>
    public class CategoriaServico : ICategoriaServico
    {
        /// <summary>
        /// Repositório da entidade Categoria
        /// </summary>
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="categoriaRepositorio">Repositório da entidade Categoria</param>
        public CategoriaServico(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        /// <summary>
        /// Seleciona todos as categorias
        /// </summary>
        /// <returns>Lista de categorias</returns>
        public async Task<IEnumerable<Categoria>> SelecionarTodos()
        {
            return await _categoriaRepositorio.SelecionarTodos();
        }

        /// <summary>
        /// Seleciona uma categoria pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único da categoria</param>
        /// <returns>Registro da categoria solicitada</returns>
        public async Task<Categoria> SelecionarPorId(long id)
        {
            return await _categoriaRepositorio.SelecionarPorId(id);
        }

        /// <summary>
        /// Cria uma nova categoria
        /// </summary>
        /// <param name="item">Nova categoria a ser criada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Inserir(Categoria item)
        {
            return await _categoriaRepositorio.Inserir(item);
        }

        /// <summary>
        /// Atualiza uma categoria
        /// </summary>
        /// <param name="item">Categoria a ser atualizada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Atualizar(Categoria item)
        {
            return await _categoriaRepositorio.Atualizar(item);
        }

        /// <summary>
        /// Exclui uma categoria
        /// </summary>
        /// <param name="item">Categoria a ser excluída</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Excluir(Categoria item)
        {
            return await _categoriaRepositorio.Excluir(item);
        }

        /// <summary>
        /// Verifica se a categoria existe por descrição
        /// </summary>
        /// <param name="descricao">Descrição da categoria</param>
        /// <returns>Valor indicando se a categoria existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao)
        {
            return await _categoriaRepositorio.ExistePorDescricao(descricao);
        }

        /// <summary>
        /// Verifica se a categoria existe por descrição para um identificador diferente da categoria a ser alterada
        /// </summary>
        /// <param name="id">Identificador único da categoria</param>
        /// <param name="descricao">Descrição da categoria</param>
        /// <returns>Valor indicando se a categoria existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao, long id)
        {
            return await _categoriaRepositorio.ExistePorDescricao(descricao, id);
        }
    }
}