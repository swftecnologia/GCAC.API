using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GCAC.Core.Entidades.InstrumentoColetivo;
using GCAC.Core.Interfaces.Repositorios.InstrumentoColetivo;
using GCAC.Infrastructure.Contextos;

namespace GCAC.Infrastructure.Repositorios.InstrumentoColetivo
{
    /// <summary>
    /// Repositório para a entidade Categoria
    /// </summary>
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        /// <summary>
        /// Contexto da aplicação
        /// </summary>
        private readonly Context _context;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="context">Contexto da aplicação</param>
        public CategoriaRepositorio(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Seleciona todos as categorias
        /// </summary>
        /// <returns>Lista de categorias</returns>
        public async Task<IEnumerable<Categoria>> SelecionarTodos()
        {
            return await _context.Categoria.ToListAsync();
        }

        /// <summary>
        /// Seleciona uma categoria pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único da categoria</param>
        /// <returns>Registro da categoria solicitada</returns>
        public async Task<Categoria> SelecionarPorId(long id)
        {
            return await _context.Categoria.FindAsync(id);
        }

        /// <summary>
        /// Cria uma nova categoria
        /// </summary>
        /// <param name="item">Nova categoria a ser criada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Inserir(Categoria item)
        {
            _context.ChangeTracker.Clear();
            _context.Categoria.Add(item);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Atualiza uma categoria
        /// </summary>
        /// <param name="item">Categoria a ser atualizada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Atualizar(Categoria item)
        {
            _context.ChangeTracker.Clear();
            _context.Categoria.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Exclui uma categoria
        /// </summary>
        /// <param name="item">Categoria a ser excluída</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Excluir(Categoria item)
        {
            _context.ChangeTracker.Clear();
            _context.Categoria.Remove(item);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Verifica se a categoria existe por descrição
        /// </summary>
        /// <param name="descricao">Descrição da categoria</param>
        /// <returns>Valor indicando se a categoria existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao)
        {
            return await _context.Categoria.AnyAsync(categoria => categoria.Descricao == descricao);
        }

        /// <summary>
        /// Verifica se a categoria existe por descrição para um identificador diferente da categoria a ser alterada
        /// </summary>
        /// <param name="id">Identificador único da categoria</param>
        /// <param name="descricao">Descrição da categoria</param>
        /// <returns>Valor indicando se a categoria existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao, long id)
        {
            return await _context.Categoria.AnyAsync(categoria => categoria.Descricao == descricao && categoria.Id != id);
        }
    }
}